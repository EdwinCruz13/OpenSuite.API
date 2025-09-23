using Entidades.Finanzas.Comprobantes;
using Microsoft.AspNetCore.Mvc;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Finanzas.Comprobantes
{
    /// <summary>
    /// Controlador para gestionar los comprobantes financieros.
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class ComprobanteController : ControllerBase
    {

        private readonly Negocio.Modulos.Finanzas.Comprobantes.ComprobantesServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// Constructor del controlador de comprobantes.
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public ComprobanteController(Negocio.Modulos.Finanzas.Comprobantes.ComprobantesServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        #region "ComprobanteTipo"
        /// <summary>
        /// obtener todos los tipos de comprobantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ComprobanteTipo>>>> GetAll()
        {
            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ListarTipos();

                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<ComprobanteTipo>>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// obtener todos los tipos de comprobantes por centro de costo y empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet("{CentroCostoID}/{EmpresaID}")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteTipo>>>> GetAllByCompany(int? CentroCostoID, int? EmpresaID)
        {
            // Validación del parámetro ID
            if (CentroCostoID == null || CentroCostoID <= 0)
                return response.BuildResponse<List<ComprobanteTipo>>(this, null, parameterName: nameof(CentroCostoID));

            if (EmpresaID == null || EmpresaID <= 0)
                return response.BuildResponse<List<ComprobanteTipo>>(this, null, parameterName: nameof(EmpresaID));


            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ListarTiposPorCentros(CentroCostoID.Value, EmpresaID.Value);

                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<ComprobanteTipo>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un tipo de comprobante por su ID, centro de costo y empresa
        /// </summary>
        /// <param name="CentroCostoID"></param>
        /// <param name="EmpresaID"></param>
        /// <param name="TipoID"></param>
        /// <returns></returns>
        [HttpGet("{CentroCostoID}/{EmpresaID}/{TipoID}")]
        public async Task<ActionResult<ApiResponse<ComprobanteTipo>>> GetByID(int? CentroCostoID, int? EmpresaID, String TipoID)
        {
            // Validación del parámetro ID
            if (CentroCostoID == null || CentroCostoID <= 0)
                return response.BuildResponse<ComprobanteTipo>(this, null, parameterName: nameof(CentroCostoID));

            if (EmpresaID == null || EmpresaID <= 0)
                return response.BuildResponse<ComprobanteTipo>(this, null, parameterName: nameof(EmpresaID));

            if (string.IsNullOrEmpty(TipoID))
                return response.BuildResponse<ComprobanteTipo>(this, null, parameterName: nameof(TipoID));


            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ObtenerTipo(CentroCostoID.Value, EmpresaID.Value, TipoID);


                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<ComprobanteTipo>(this, null, exception: ex);
            }
        }

        #endregion




    }
}
