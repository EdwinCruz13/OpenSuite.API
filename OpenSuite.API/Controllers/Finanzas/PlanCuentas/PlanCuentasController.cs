using Microsoft.AspNetCore.Mvc;
using System.Net;
using OpenSuite.API.Tools.Responses;
using Negocio.Modulos.Finanzas.PlanCuentas;
using Entidades.Finanzas.PlanCuentas;

using Shared.ExcelReader;



namespace OpenSuite.API.Controllers.Finanzas.PlanCuentas
{
    /// <summary>
    /// Controlador para la gestión del Plan de Cuentas
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class PlanCuentasController : ControllerBase
    {

        private readonly PlanCuentasServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// Constructor del controlador de Plan de Cuentas
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public PlanCuentasController(PlanCuentasServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }


        /// <summary>
        /// obtener todos los niveles del plan de cuentas en formato plano
        /// </summary>
        /// <returns></returns>
        [HttpGet("empresaID")]
        public async Task<ActionResult<ApiResponse<List<Entidades.Finanzas.PlanCuentas.PlanCuenta>>>> GetAll(int? empresaID)
        {
            // Valida el parámetro empresaID
            if (empresaID == null || empresaID <= 0)
                return response.BuildResponse<List<Entidades.Finanzas.PlanCuentas.PlanCuenta>>(this, null, parameterName: nameof(empresaID));

            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ListarPlanCuentas(empresaID.Value);


                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, listado);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<PlanCuenta>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Obtener el plan de cuentas en formato jerárquico (árbol) por empresaID.
        /// </summary>
        /// <param name="empresaID"></param>
        /// <returns></returns>
        [HttpGet("jerarquia/{empresaID}")]
        public async Task<ActionResult<ApiResponse<List<Entidades.Finanzas.PlanCuentas.PlanCuentaEstructurada>>>> ObtenerJerarquia(int? empresaID)
        {
            // Valida el parámetro empresaID
            if (empresaID == null || empresaID <= 0)
                return response.BuildResponse<List<PlanCuentaEstructurada>>(this, null, parameterName: nameof(empresaID));


            try
            {
                // llama a negocio para obtener el plan de cuenta en formato jerárquico
                var resultado = await negocio.ListarPlanCuenta_Estructurada(empresaID.Value);
                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<PlanCuentaEstructurada>>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// Obtener una cuenta específica del plan de cuentas por empresaID y cuentaID.
        /// </summary>
        /// <param name="empresaID"></param>
        /// <param name="cuentaID"></param>
        /// <returns></returns>
        [HttpGet("buscar/empresaID/cuentaID/IncluyeHijos")]
        public async Task<ActionResult<ApiResponse<PlanCuenta>>> search(int? empresaID, string? cuentaID, bool IncluyeHijos = false)
        {
            // Valida el parámetro empresaID
            if (empresaID <= 0)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(empresaID));

            if (string.IsNullOrEmpty(cuentaID))
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(cuentaID));


            try
            {
                // Llama al método del negocio para obtener las naturalezas
                var listado = await negocio.ObtenerPlanCuenta(empresaID.Value, cuentaID, IncluyeHijos);


                // Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, listado);


            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<PlanCuenta>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// Insertar un nuevo plan de cuentas, incluyendo sus cuentas hijas en formato árbol.
        /// </summary>
        /// <param name="planCuenta"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PlanCuenta>>> Add([FromBody] PlanCuentaDTO planCuenta)
        {
            // Valida el parámetro empresaID
            if (planCuenta == null)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(planCuenta));
            try
            {
                // llama a negocio para insertar el plan de cuenta
                var created = await negocio.InsertarNodo(planCuenta);


                ///  Retorna la lista de naturalezas con una respuesta de éxito
                return response.BuildResponse(this, created, HttpStatusCode.Created);


            }
            catch (Exception ex)
            {
                return response.BuildResponse<PlanCuenta>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// Editar una cuenta existente en el plan de cuentas.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ApiResponse<PlanCuenta>>> Update([FromBody] PlanCuentaDTO dto)
        {
            if (dto == null)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(dto));

            if (dto.CuentaID <= 0)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(dto.CuentaID));

            if (dto.PadreID <= 0)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(dto.PadreID));



            //validar si existe
            var existeCuenta = await negocio.ObtenerPlanCuenta(dto.EmpresaID, dto.CuentaID.ToString());
            var existtePadre = await negocio.ObtenerPlanCuenta(dto.EmpresaID, dto.PadreID.ToString());

            if (existeCuenta == null)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(dto.CuentaID), errorMessage: $"la cuenta ${dto.CuentaID} no existe");

            if (existtePadre == null)
                return response.BuildResponse<PlanCuenta>(this, null, parameterName: nameof(dto.PadreID), errorMessage: $"la cuenta padre ${dto.PadreID} no existe");




            try
            {
                /// llama a negocio para actualizar el plan de cuenta
                var resultado = await negocio.ActualizarPlanCuenta(dto);

                //  Retorna la lista de PlanCuenta con una respuesta de éxito pero sin contenidossd
                return response.BuildResponse<PlanCuenta>(this, resultado, HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return response.BuildResponse<PlanCuenta>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// Importar un archivo Excel para insertar múltiples planes de cuentas.
        /// 1 - valida si el archivo fue adjuntado
        /// 2 - valida la extension
        /// 3 - valida las columnas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("ImportExcel")]
        [Consumes("multipart/form-data")] // esta shit indica que el endpoint acepta datos de formulario con archivos adjuntos, solo hay que validar que sea un excel
        public async Task<ActionResult<ApiResponse<List<PlanCuentaDTO>>>> ImportExcel(IFormFile file)
        {
            // validad si hay archivos y la extension
            if (file == null || file.Length == 0)
                return response.BuildResponse<List<PlanCuentaDTO>>(this, null, parameterName: nameof(file));



            try
            {
                //
                var resultado = await negocio.InsertarDesdeExcelAsync(file);

                // retorna el objecto creado
                return response.BuildResponse(this, resultado, HttpStatusCode.Created);


            }
            catch (Exception ex)
            {
                return response.BuildResponse<List<PlanCuentaDTO>>(this, null, exception: ex );
            }

        }
    }
}
