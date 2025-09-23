
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Finanzas.PlanCuentas;
using OpenSuite.API.Tools.Responses;
using Entidades.Finanzas.PlanCuentas;

namespace OpenSuite.API.Controllers.Finanzas.PlanCuentas
{
    /// <summary>
    /// Controlador para gestionar los niveles del plan de cuentas.
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class PlanCuentaNivelController : ControllerBase
    {
        private readonly PlanCuentasServicios negocio;
        private readonly IResponseService response;


        /// <summary>
        /// Constructor del controlador de niveles del plan de cuentas.
        /// </summary>
        /// <param name="_negocio"></param>
        public PlanCuentaNivelController(PlanCuentasServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }


        /// <summary>
        /// obtener todos los niveles del plan de cuentas
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PlanCuentaNivel>>>> GetAll()
        {
            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ListarNiveles();

                // Retorna la lista con una respuesta de éxito
                return response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<PlanCuentaNivel>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un nivel del plan de cuentas por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public async Task<ActionResult<ApiResponse<PlanCuentaNivel>>> GetById(int? id)
        {

            // Validación del parámetro ID
            if (id == null || id <= 0)
                return response.BuildResponse<PlanCuentaNivel>(this, null, parameterName: nameof(id));

            try
            {
                // Llama al método del negocio para obtener la naturaleza por ID
                var item = await negocio.ObtenerNivel(id.Value);

                // Retorna la naturaleza con una respuesta de éxito
                return response.BuildResponse(this, item);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<PlanCuentaNivel>(this, null, exception: ex);
            }
        }
    }
}
