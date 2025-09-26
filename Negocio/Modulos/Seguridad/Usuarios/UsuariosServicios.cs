using AutoMapper;
using Datos.EF.Context;
using Datos.EF;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Shared.Encrypt;

namespace Negocio.Modulos.Seguridad.Usuarios
{
    public class UsuariosServicios
    {
        private readonly DatosSQL<Usuario> _repository;
        private readonly IMapper _mapper;
        private readonly OpenSuiteDbContext _context;
        private readonly PasswordService _passwordService;

        public UsuariosServicios(DatosSQL<Usuario> repository, IMapper mapper, OpenSuiteDbContext context, PasswordService passwordService)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _passwordService = passwordService;
        }

        /// <summary>
        /// Listar todos los usuarios activos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entidades.Seguridad.Usuarios.Usuario>> ListarUsuarios()
        {
            try
            {
                var usuarios = await _repository.GetAllAsync(
                                filter: u => u.Estado.Consecutivo == 1,
                                orderBy: q => q.OrderBy(u => u.UsuarioID),
                                include: q => q
                                    .Include(e => e.Persona)
                                    .ThenInclude(f => f.EntidadTipo)
                                    .Include(e => e.UsuarioPerfil)
                                    .ThenInclude(p => p.Perfil),
                                asNoTracking: true
            );
                return _mapper.Map<List<Entidades.Seguridad.Usuarios.Usuario>>(usuarios);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtener un usuario por ID o Login
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Seguridad.Usuarios.Usuario?> ObtenerUsuario(string valor)
        {
            try
            {
                // Definir el predicado según sea entero (ID) o texto (Login)
                Expression<Func<Usuario, bool>> predicate = int.TryParse(valor, out int id)
                    ? e => e.UsuarioID == id
                    : e => e.Login == valor;

                // Obtener el usuario con sus perfiles asociados
                var usuario = await _repository.GetAsync(
                    predicate: predicate,
                    include: q => q
                                    .Include(e => e.Persona)
                                    .ThenInclude(f => f.EntidadTipo)
                                    .Include(e => e.UsuarioPerfil)
                                    .ThenInclude(p => p.Perfil),
                    asNoTracking: true
                );

                return _mapper.Map<Entidades.Seguridad.Usuarios.Usuario>(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtener un usuario por ID
        /// </summary>
        /// <param name="UsuarioID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Seguridad.Usuarios.Usuario?> ObtenerUsuario(int UsuarioID)
        {
            try
            {
                
                // Obtener el usuario con sus perfiles asociados
                var usuario = await _repository.GetByIdAsync(
                    keySelector: u => u.UsuarioID,  
                    keyValue: UsuarioID,
                    include: q => q
                                    .Include(e => e.Persona)
                                    .ThenInclude(f => f.EntidadTipo)
                                    .Include(e => e.UsuarioPerfil)
                                    .ThenInclude(p => p.Perfil),
                    asNoTracking: true
                );

                return _mapper.Map<Entidades.Seguridad.Usuarios.Usuario>(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Crear un nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Seguridad.Usuarios.Usuario> CrearUsuario(Entidades.Seguridad.Usuarios.UsuarioDTO usuario)
        {
            try
            {
                //verificar si el usuarioExiste mediante login
                var usuarioExiste = await _repository.GetAllAsync(
                    filter: u => u.Login == usuario.Login,
                    asNoTracking: true
                );

                /// si el usuario existe, lanzar una excepción
                if (usuarioExiste.Any())
                {
                    throw new Exception("El usuario ya existe");
                }

                // obtener el maxId De usuario
                var maxId = await _repository.GetMaxIdAsync(u => u.UsuarioID);

                // encriptar la contraseña antes de guardarla
                var hashPassword = _passwordService.HashPassword(usuario.Contrasena);


                //setear nuevos valores a propiedades
                usuario.UsuarioID = maxId + 1;
                usuario.Contrasena = hashPassword;
                usuario.EstadoID = 1; // Activo
                usuario.Login = usuario.Login.ToUpper().Trim(); // en mayuscula a webo


                var usuarioEntity = _mapper.Map<Usuario>(usuario);
                var UsuarioCreado = await _repository.InsertAsync(usuarioEntity);
                return _mapper.Map<Entidades.Seguridad.Usuarios.Usuario>(UsuarioCreado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Boolean> ActualizarUsuario(Entidades.Seguridad.Usuarios.UsuarioDTO dto)
        {
            try
            {
                /// verificar si el usuario existe
                var usuarioExiste = await _repository.GetByIdAsync(
                    keySelector: c => c.UsuarioID,
                    keyValue: dto.UsuarioID,
                    asNoTracking: true
                );

                // si el usuario no existe, lanzar una excepción
                if (usuarioExiste == null)
                    throw new Exception("El Usuario no existe");


                // encriptar la contraseña antes de guardarla
                var hashPassword = _passwordService.HashPassword(dto.Contrasena);

                dto.Contrasena = hashPassword;
                dto.EstadoID = dto.EstadoID; 
                dto.Login = dto.Login.ToUpper().Trim(); // en mayuscula a webo
                dto.FechaGrabado = usuarioExiste.FechaGrabado; // mantener la fecha de grabado original


                // mapear el dto a modelo
                var usuarioActualizar = _mapper.Map<Usuario>(dto);

                // actualizar la persona
                var usuarioActualizado = await _repository.UpdateAsync(usuarioActualizar);

                // retornar la persona actualizada mapeada a dto
                return usuarioActualizado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
