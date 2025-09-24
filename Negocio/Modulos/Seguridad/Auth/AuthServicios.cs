using AutoMapper;
using Datos.EF;
using Datos.EF.Modelos;
using Entidades.Seguridad.Auth;
using Entidades.Seguridad.Permisos;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using Shared.Encrypt;
using Shared.JWT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// validar el usuario y la contraseña, y si son correctos, genera un token JWT junto con los roles y permisos del usuario.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<(bool Success, string? Token, UsuarioAutenticado user, List<string>? Roles, List<string>? Permisos, string? Error)> ObtenerUsuario(string username, string password)
        {
            //objeto para retornar
            UsuarioAutenticado usuarioAutenticado = new UsuarioAutenticado();

            try
            {
                //comprobar si el usuario existe
                var usuario = await _repository.GetAsync(
                    predicate: e => e.Login == username,
                    include: q => q
                             .Include(e => e.Persona)
                             .Include(e => e.UsuarioPerfil)
                             .ThenInclude(e => e.Perfil)
                             .ThenInclude(e => e.Permiso),
                    asNoTracking: true
                );
                if (usuario == null) return (false, null, null, null, null, "Usuario no encontrado");

                //verificar el password encriptando
                bool passwordValid = _passwordService.VerifyPassword(password, usuario.Contrasena);
                if(passwordValid== false) return (false, null, null, null, null, "Contraseña incorrecta");



                //obtener los roles del usuario
                var roles = usuario.UsuarioPerfil.Select(up => up.Perfil.nPerfil).ToList();
                //obtener los permisos del usuario
                var permisos = usuario.UsuarioPerfil
                    .SelectMany(up => up.Perfil.Permiso)
                    .Select(p => p.Acciones.nAccion)
                    .Distinct()
                    .ToList();



                //setear los datos del usuario autenticado
                usuarioAutenticado.UsuarioID = usuario.UsuarioID;
                usuarioAutenticado.nUsuario = usuario.Persona.nPersona;
                usuarioAutenticado.Usuario = usuario.Login;
                usuarioAutenticado.Perfiles = _mapper.Map<List<Entidades.Seguridad.Perfiles.Perfil>> (usuario.UsuarioPerfil.Select(x => x.Perfil).ToList());
                //usuarioAutenticado.Acciones =


                //generar el token basado en el login y los roles
                var token = _jwt.GenerateToken(usuarioAutenticado);



                //retornar exito, token, roles, permisos
                return (true, token, usuarioAutenticado, roles, permisos, null);


            }
            catch (Exception ex)
            {
                return (false, null, null, null, null, ex.Message);
            }
        }



    }
}
