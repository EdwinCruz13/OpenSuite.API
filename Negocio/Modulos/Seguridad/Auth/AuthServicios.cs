using AutoMapper;
using Datos.EF;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;
using Shared.Encrypt;
using Shared.JWT;
using System.Data;

namespace Negocio.Modulos.Seguridad.Auth
{
    public class AuthServicios
    {
        private readonly DatosSQL<Usuario> _repository;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;
        private readonly JwtTokenService _jwt;

        /// <summary>
        /// Constructor de la clase AuthServicios
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="passwordService"></param>
        /// <param name="jwt"></param>
        public AuthServicios(DatosSQL<Usuario> repository, IMapper mapper, PasswordService passwordService, JwtTokenService jwt)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordService = passwordService;
            _jwt = jwt;
        }

        /// <summary>
        /// Obtener un usuario autenticado, sus roles y permisos, y generar un token JWT.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<(
            bool Success, string? Token, 
            Entidades.Seguridad.Auth.UsuarioAutenticado? user,
            List<Entidades.Seguridad.Perfiles.Perfil>? Roles,
            List<Entidades.Seguridad.Modulos.Modulo>? Modulos,
            List<Entidades.Seguridad.Modulos.SubModulo>? SubModulos,
            List<Entidades.Seguridad.Modulos.Accion>? Acciones,
            string? Error)> 
            ObtenerUsuario(string username, string password)
        {
            //objeto para retornar
            Entidades.Seguridad.Auth.UsuarioAutenticado usuarioAutenticado = new Entidades.Seguridad.Auth.UsuarioAutenticado();
            List<Entidades.Seguridad.Perfiles.Perfil> perfiles = new List<Entidades.Seguridad.Perfiles.Perfil>();
            List<Entidades.Seguridad.Modulos.Modulo> modulos = new List<Entidades.Seguridad.Modulos.Modulo>();
            List<Entidades.Seguridad.Modulos.SubModulo> subModulos = new List<Entidades.Seguridad.Modulos.SubModulo>();
            List<Entidades.Seguridad.Modulos.Accion> acciones = new List<Entidades.Seguridad.Modulos.Accion>();

            try
            {

                ///////////////////////////////////////////////////////////////////////
                //validar usuario y jwt
                ///////////////////////////////////////////////////////////////////////

                //comprobar si el usuario existe
                var usuario = await _repository.GetAsync(
                    predicate: e => e.Login == username,
                    include: q => q
                             .Include(e => e.Persona)
                             .Include(e => e.UsuarioPerfil)
                             .ThenInclude(e => e.Perfil)
                             .ThenInclude(e => e.Permiso)
                                .ThenInclude(a => a.Acciones)
                                .ThenInclude(s => s.SubModulo)
                                .ThenInclude(m => m.Modulo),
                    asNoTracking: true
                );
                // Cambia los valores de retorno nulos explícitamente a valores predeterminados no nulos
                if (usuario == null) 
                    return (false, null, new Entidades.Seguridad.Auth.UsuarioAutenticado(), new List<Entidades.Seguridad.Perfiles.Perfil>(), new List<Entidades.Seguridad.Modulos.Modulo>(), new List<Entidades.Seguridad.Modulos.SubModulo>(), new List<Entidades.Seguridad.Modulos.Accion>(), "Usuario no encontrado");

                //verificar el password encriptando
                bool passwordValid = _passwordService.VerifyPassword(password, usuario.Contrasena);
                if(passwordValid== false) return (false, null, null, null, null, null, null, "Contraseña incorrecta");



                ///////////////////////////////////////////////////////////////////////
                //setear los datos del usuario
                ///////////////////////////////////////////////////////////////////////
                usuarioAutenticado.UsuarioID = usuario.UsuarioID;
                usuarioAutenticado.nUsuario = usuario.Persona.nPersona;
                usuarioAutenticado.Usuario = usuario.Login;
                usuarioAutenticado.PhotoUrl = "";

                //obtener los roles del usuario
                perfiles = usuario.UsuarioPerfil.Select(x => _mapper.Map<Entidades.Seguridad.Perfiles.Perfil>(x.Perfil)).ToList();


                //obtener los permisos del usuario
                acciones = usuario.UsuarioPerfil
                    .SelectMany(up => up.Perfil.Permiso)
                    .Select(p => p.Acciones)
                    .Distinct()
                    .Select(a => _mapper.Map<Entidades.Seguridad.Modulos.Accion>(a))
                    .ToList();

                subModulos = usuario.UsuarioPerfil
                    .SelectMany(up => up.Perfil.Permiso)
                    .Select(p => p.Acciones.SubModulo)
                    .Distinct()
                    .Select(s => _mapper.Map<Entidades.Seguridad.Modulos.SubModulo>(s))
                    .ToList();

                modulos = usuario.UsuarioPerfil
                    .SelectMany(up => up.Perfil.Permiso)
                    .Select(p => p.Acciones.SubModulo.Modulo)
                    .Distinct()
                    .Select(m => _mapper.Map<Entidades.Seguridad.Modulos.Modulo>(m))
                    .ToList();



                //generar el token basado en el login y los roles
                var token = _jwt.GenerateToken(usuarioAutenticado, perfiles);



                //retornar exito, token, roles, permisos
                return (true, token, usuarioAutenticado, perfiles, modulos, subModulos, acciones, null);


            }
            catch (Exception ex)
            {
                return (false, null, null, null, null, null, null, ex.Message);
            }
        }



    }
}
