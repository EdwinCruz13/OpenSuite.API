
using Azure;
using Entidades.Seguridad.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Seguridad.Usuarios;
using OpenSuite.API.Tools.Responses;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenSuite.API.Controllers.Seguridad.Usuarios
{
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuariosServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// constructor de controlador de usuarios
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public UsuarioController(UsuariosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        /// <summary>
        /// Listar todos los usuarios
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Usuario>>>> GetAll()
        {

            try
            {
                var resultado = await negocio.ListarUsuarios();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Usuario>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Obtener usuario por ID
        /// </summary>
        /// <param name="UsuarioID"></param>
        /// <returns></returns>

        [HttpGet("{UsuarioID}")]
        public async Task<ActionResult<ApiResponse<Usuario>>> GetByID(int? UsuarioID)
        {
            if (UsuarioID == null) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(UsuarioID));
            try
            {
                var resultado = await negocio.ObtenerUsuario(UsuarioID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Usuario>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Buscar usuario por ID o Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpGet("buscar/{usuario}")]
        public async Task<ActionResult<ApiResponse<Usuario>>> search(string? usuario)
        {
            if (string.IsNullOrEmpty(usuario)) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(usuario));
            try
            {
                var resultado = await negocio.ObtenerUsuario(usuario);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Usuario>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Guardar un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Usuario>>> Save([FromBody] UsuarioDTO dto)
        {
            if (dto == null) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(dto));

            try
            {
                // Crear el usuario
                var resultado = await negocio.CrearUsuario(dto);

                // Obtener el usuario creado con sus detalles completos
                var UsuarioCreado = await negocio.ObtenerUsuario(resultado.UsuarioID.ToString());

                /// Retornar la respuesta con el usuario creado
                return CreatedAtAction(
                    nameof(GetByID),                     
                    new { UsuarioID = UsuarioCreado?.UsuarioID }, 
                    new ApiResponse<Usuario>(UsuarioCreado, 201)
                );
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Usuario>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult<ApiResponse<Usuario>>> Update(int? id, [FromBody] UsuarioDTO dto)
        {
            if(id == null || id <= 0) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(id));
            if (dto == null) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(dto));
            if (string.IsNullOrEmpty(dto.Login)) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(dto.Login));
            if (string.IsNullOrEmpty(dto.Contrasena)) return response.BuildResponse<Usuario>(this, null, parameterName: nameof(dto.Contrasena));

            try
            {
                // Actualizar la persona
                var resultado = await negocio.ActualizarUsuario(dto);

                return response.BuildResponse<Usuario>(this, null, forcedStatus: HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Usuario>(this, null, exception: ex);
            }
        }
    }
}
