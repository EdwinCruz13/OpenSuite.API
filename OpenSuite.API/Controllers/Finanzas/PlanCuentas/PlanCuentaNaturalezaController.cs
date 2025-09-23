
using Microsoft.AspNetCore.Mvc;
using OpenSuite.API.Tools.Responses;
using Entidades.Finanzas.PlanCuentas;

namespace OpenSuite.API.Controllers.Finanzas.PlanCuentas
{
    /// <summary>
    /// Controlador para gestionar las naturalezas del plan de cuentas.
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class PlanCuentaNaturalezaController : ControllerBase
    {

        private readonly Negocio.Modulos.Finanzas.PlanCuentas.PlanCuentasServicios negocio;
        private readonly IResponseService response;


        /// <summary>
        /// Constructor del controlador de naturalezas del plan de cuentas.
        /// </summary>
        /// <param name="_negocio"></param>
        public PlanCuentaNaturalezaController(Negocio.Modulos.Finanzas.PlanCuentas.PlanCuentasServicios _negocio, IResponseService responseService)
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

                // Detecta automáticamente 200, 404 o 204
                return response.BuildResponse(this, listado); 

            }
            catch (Exception ex)
            {
                return response.BuildResponse<List<PlanCuentaNivel>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener una naturaleza del plan de cuentas por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public async Task<ActionResult<ApiResponse<PlanCuentaNaturaleza>>> GetById(int? id)
        {

            // Validación del parámetro ID
            if (id == null || id <= 0)
                return response.BuildResponse<PlanCuentaNaturaleza>(this, null, parameterName: nameof(id));

            try
            {
                // Llama al método del negocio para obtener la naturaleza por ID
                var item = await negocio.ObtenerNaturaleza(id.Value);

                // Detecta automáticamente 200, 404 o 204
                return response.BuildResponse(this, item);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<PlanCuentaNaturaleza>(this, null, exception: ex);
            }
        }
    }
}
