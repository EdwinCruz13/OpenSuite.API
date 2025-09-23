using Entidades.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Catalogos
{
    [ApiController]
    [Route("api/opensuite/estado")]
    public class EstadoController : Controller
    {
        private readonly IResponseService response;
        private readonly CatalogosServicios negocio;

        /// <summary>
        /// Constructor de la clase EstadoController
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public EstadoController(CatalogosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        /// <summary>
        /// obtener todos los estados
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Estado>>>> GetAll()
        {
            try
            {
                /// Llama al método del servicio para obtener la lista de estados
                var resultado = await negocio.ListarEstados();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Estado>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener todos los estados por empresa
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>

        [HttpGet("{IdEmpresa}")]
        public async Task<ActionResult<ApiResponse<List<Estado>>>> GetAllByCompany(int? IdEmpresa)
        {
            if (IdEmpresa == null || IdEmpresa <= 0) return response.BuildResponse<List<Estado>>(this, null, parameterName: "IdEmpresa");

            try
            {
                var resultado = await negocio.ListarEstadosPorEmpresa(IdEmpresa.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {

                return response.BuildResponse<List<Estado>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener todos los estados por empresa, módulo y submódulo
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <param name="ModuloID"></param>
        /// <param name="SubModulo"></param>
        /// <returns></returns>
        [HttpGet("{IdEmpresa}/{ModuloID}/{SubModuloID}")]
        public async Task<ActionResult<ApiResponse<List<Estado>>>> GetAllByModule(int? IdEmpresa, int? ModuloID, int? SubModuloID)
        {
            if (IdEmpresa == null || IdEmpresa <= 0) return response.BuildResponse<List<Estado>>(this, null, parameterName: "IdEmpresa");
            if (ModuloID == null || ModuloID <= 0) return response.BuildResponse<List<Estado>>(this, null, parameterName: "ModuloID");
            if (SubModuloID == null || SubModuloID <= 0) return response.BuildResponse<List<Estado>>(this, null, parameterName: "SubModulo");
            try
            {
                var resultado = await negocio.ListarEstadosPorModulo(IdEmpresa.Value, ModuloID.Value, SubModuloID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                return response.BuildResponse<List<Estado>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener un estado por ID, empresa, módulo y submódulo
        /// </summary>
        /// <param name="estadoID"></param>
        /// <param name="IdEmpresa"></param>
        /// <param name="ModuloID"></param>
        /// <param name="SubModulo"></param>
        /// <returns></returns>
        [HttpGet("{EstadoID}/{IdEmpresa}/{ModuloID}/{SubModuloID}")]
        public async Task<ActionResult<ApiResponse<Estado>>> GetByID(int? estadoID, int? IdEmpresa, int? ModuloID, int? SubModulo)
        {
            if (estadoID == null || estadoID <= 0) return response.BuildResponse<Estado>(this, null, parameterName: "estadoID");
            if (IdEmpresa == null || IdEmpresa <= 0) return response.BuildResponse<Estado>(this, null, parameterName: "IdEmpresa");
            if (ModuloID == null || ModuloID <= 0) return response.BuildResponse<Estado>(this, null, parameterName: "ModuloID");
            if (SubModulo == null || SubModulo <= 0) return response.BuildResponse<Estado>(this, null, parameterName: "SubModulo");
            try
            {
                var resultado = await negocio.ObtenerEstado(estadoID.Value, IdEmpresa.Value, ModuloID.Value, SubModulo.Value );
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                return response.BuildResponse<Estado>(this, null, exception: ex);
            }
        }

    }
}
