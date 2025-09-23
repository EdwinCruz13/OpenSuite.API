using Azure;
using Entidades.Seguridad.Modulos;
using Microsoft.AspNetCore.Mvc;

using Negocio.Modulos.Seguridad.Modulos;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Seguridad.Modulos
{
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class ModulosController : ControllerBase
    {
        private readonly ModulosServicios _negocio;
        private readonly IResponseService _response;

        /// <summary>
        /// Constructor del controlador de módulos.
        /// </summary>
        /// <param name="negocio"></param>
        /// <param name="responseService"></param>
        public ModulosController(ModulosServicios negocio, OpenSuite.API.Tools.Responses.IResponseService responseService)
        {
            _negocio = negocio;
            _response = responseService;
        }

        /// <summary>
        /// Obtener todos los módulos con sus submódulos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Modulo>>>> GetAll()
        {
            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await _negocio.ListarModulos();

                // Detecta automáticamente 200, 404 o 204
                return _response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                return _response.BuildResponse<List<Modulo>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Obtener un módulo por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public async Task<ActionResult<ApiResponse<Modulo>>> GetById(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return _response.BuildResponse<Modulo>(this, null, System.Net.HttpStatusCode.BadRequest, "El ID del módulo es inválido.", nameof(id));
                }
                var modulo = await _negocio.ObtenerModulo(id.Value);
                return _response.BuildResponse(this, modulo);
            }
            catch (Exception ex)
            {
                return _response.BuildResponse<Modulo>(this, null, exception: ex);
            }
        }
    }
}
