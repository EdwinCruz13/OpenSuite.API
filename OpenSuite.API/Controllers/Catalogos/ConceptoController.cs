using Microsoft.AspNetCore.Mvc;

using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;
using Entidades.Catalogos;

namespace OpenSuite.API.Controllers.Catalogos
{
    /// <summary>
    /// Controlador para gestionar conceptos en el sistema.
    /// </summary>

    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class ConceptoController : ControllerBase
    {

        private readonly CatalogosServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// Constructor del controlador de conceptos.
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public ConceptoController(CatalogosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        #region "conceptos"

        /// <summary>
        /// obtener todos los conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Concepto>>>> GetAllConcept()
        {
            try
            {
                var resultado = await negocio.ListarConcepto();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Concepto>>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un concepto por ID
        /// </summary>
        /// <param name="conceptoID"></param>
        /// <returns></returns>
        [HttpGet("{conceptoID}")]
        public async Task<ActionResult<ApiResponse<Concepto>>> GetConceptByID(int? conceptoID)
        {
            if (conceptoID == null || conceptoID <= 0) return response.BuildResponse<Concepto>(this, data: null, parameterName: nameof(conceptoID));
            try
            {
                var resultado = await negocio.ObtenerConcepto(conceptoID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Concepto>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un concepto por tipoID
        /// </summary>
        /// <param name="tipoID"></param>
        /// <returns></returns>
        [HttpGet("porTipo/{tipoID}")]
        public async Task<ActionResult<ApiResponse<List<Concepto>>>> GetConceptByTiypeID(int? tipoID)
        {
            if (tipoID == null || tipoID <= 0) return response.BuildResponse<List<Concepto>>(this, data: null, parameterName: nameof(tipoID));
            try
            {
                var resultado = await negocio.ObtenerConceptoPorTipo(tipoID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Concepto>>(this, data: null, exception: ex);   
            }
        }

        /// <summary>
        /// obtener todos los tipos de conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet("tipo")]
        public async Task<ActionResult<ApiResponse<List<ConceptoTipo>>>> GetAllConceptTypes()
        {
            try
            {
                var resultado = await negocio.ListarConceptoTipos();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<ConceptoTipo>>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un tipo de concepto por ID
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        [HttpGet("tipo/{typeID}")]
        public async Task<ActionResult<ApiResponse<ConceptoTipo>>> GetConceptTypeByID(int? typeID)
        {
            if (typeID == null || typeID <= 0) return response.BuildResponse<ConceptoTipo>(this, data: null, parameterName: nameof(typeID));
            try
            {
                var resultado = await negocio.ObtenerConceptoTipo(typeID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<ConceptoTipo>(this, data: null, exception: ex);
            }
        }


        #endregion

    }
}
