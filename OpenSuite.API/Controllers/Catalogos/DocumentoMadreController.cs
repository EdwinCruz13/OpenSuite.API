using Entidades.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Catalogos
{
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class DocumentoMadreController : ControllerBase
    {
        private readonly CatalogosServicios negocio;
        private readonly IResponseService response;
        public DocumentoMadreController(CatalogosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        #region "documentos"
        /// <summary>
        /// obtener todos los documentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<DocumentoMadre>>>> GetAllDocuments()
        {
            try
            {
                var resultado = await negocio.ListarDocumentos();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<DocumentoMadre>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un documento por ID
        /// </summary>
        /// <param name="conceptoID"></param>
        /// <returns></returns>
        [HttpGet("{documentoID}")]
        public async Task<ActionResult<ApiResponse<DocumentoMadre>>> GetDocumentByID(int? documentoID)
        {
            if (documentoID == null || documentoID <= 0) return response.BuildResponse<DocumentoMadre>(this, null, parameterName: "documentoID");
            try
            {
                var resultado = await negocio.ObtenerDocumento(documentoID.Value);

                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<DocumentoMadre>(this, null, exception: ex);
            }
        }
        #endregion
    }
}
