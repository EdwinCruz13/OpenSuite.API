using Entidades.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Catalogos
{
    /// <summary>
    /// Controlador para gestionar los impuestos
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class ImpuestoController : ControllerBase
    {
        private readonly CatalogosServicios negocio;
        private readonly IResponseService response;

        public ImpuestoController(CatalogosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }



        #region "impuestos"
        /// <summary>
        /// obtener todos los conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Impuesto>>>> GetAllTaxes()
        {
            try
            {
                var resultado = await negocio.ListarImpuestos();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Impuesto>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un concepto por ID
        /// </summary>
        /// <param name="conceptoID"></param>
        /// <returns></returns>
        [HttpGet("{impuestosID}")]
        public async Task<ActionResult<ApiResponse<Impuesto>>> GetTexByID(int? impuestosID)
        {
            if (impuestosID == null || impuestosID <= 0) return response.BuildResponse<Impuesto>(this, null, parameterName: "impuestosID");
            try
            {
                var resultado = await negocio.ObtenerImpuestos(impuestosID.Value);

                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Impuesto>(this, null, exception: ex);
            }
        }
        #endregion
    }
}
