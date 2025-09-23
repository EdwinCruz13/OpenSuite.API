using Entidades.Configuraciones;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Configuraciones.Empresas;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Configuraciones.Empresas
{

    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class EmpresaController : ControllerBase
    {

        private readonly EmpresasServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// constructor de controlador de empresas
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public EmpresaController(EmpresasServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        /// <summary>
        /// Listar todas las empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Empresa>>>> GetAll()
        {
            try
            {
                var resultado = await negocio.ListarEmpresas();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Empresa>>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// Detalle de una empresa por ID
        /// </summary>
        /// <param name="EmpresaID"></param>
        /// <returns></returns>
        [HttpGet("{EmpresaID}")]
        public async Task<ActionResult<ApiResponse<Empresa>>> GetByID(int? EmpresaID)
        {
            if(EmpresaID == null) return response.BuildResponse<Empresa>(this, data: null, parameterName: "EmpresaID");
            try
            {
                var resultado = await negocio.ObtenerEmpresa(EmpresaID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Empresa>(this, data: null, exception: ex);
            }
        }







        /// <summary>
        /// pruebas de endpoint para ver si funciona un procedimiento almacenado
        /// </summary>
        /// <param name="EmpresaID"></param>
        /// <returns></returns>

        [HttpGet("/test/{EmpresaID}")]
        public async Task<ActionResult<ApiResponse<Empresa>>> eejecutar(int? EmpresaID)
        {
            if (EmpresaID == null) return response.BuildResponse<Empresa>(this, data: null, parameterName: "EmpresaID");
            try
            {
                var resultado = await negocio.verEmpresa(EmpresaID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Empresa>(this, data: null, exception: ex);
            }
        }
    }
}
