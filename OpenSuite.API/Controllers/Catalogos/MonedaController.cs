using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;
using Entidades.Catalogos;
using System.Reflection.Metadata.Ecma335;

namespace OpenSuite.API.Controllers.Catalogos
{
    /// <summary>
    /// Controlador para gestionar monedas en el sistema.
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class MonedaController : ControllerBase
    {
        private readonly CatalogosServicios negocio;
        private readonly IResponseService response;

        public MonedaController(CatalogosServicios _negocio, IResponseService _response)
        {
            negocio = _negocio;
            response = _response;
        }



        #region "monedas"
        /// <summary>
        /// obtener todas las monedas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Moneda>>>> GetAllCurrency()
        {
            try
            {
                var resultado = await negocio.ListarMonedas();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Moneda>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener una moneda por ID
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        [HttpGet("{monedaID}")]
        public async Task<ActionResult<ApiResponse<Moneda>>> GetCurrencyByID(int? monedaID)
        {
            if (monedaID == null || monedaID <= 0) return response.BuildResponse<Moneda>(this, null, parameterName: nameof(monedaID));
            try
            {
                var resultado = await negocio.ObtenerMoneda(monedaID.Value);

                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
               return response.BuildResponse<Moneda>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// obtener todas las denominaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet("denominaciones")]
        public async Task<ActionResult<ApiResponse<List<MonedaDenominacion>>>> GetAllDenominations()
        {
            try
            {
                var resultado = await negocio.ListarDenominaciones();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<MonedaDenominacion>>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtener una denominacion por ID
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        [HttpGet("denominaciones/{id}")]
        public async Task<ActionResult<ApiResponse<MonedaDenominacion>>> GetDenominationsByID(int? id)
        {
            if (id == null || id <= 0) return response.BuildResponse<MonedaDenominacion>(this, null, parameterName: nameof(id));
            try
            {
                var resultado = await negocio.ObtenerDenominacion(id.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
               return response.BuildResponse<MonedaDenominacion>(this, null, exception: ex);
            }
        }

        /// <summary>
        /// obtiene las denominaciones de una moneda
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        [HttpGet("tasacambio/tasaactual/{origen}/{destino}")]
        public async Task<ActionResult<ApiResponse<TasaCambio>>> GetCurrentExchange(int? origen, int? destino)
        {
            if (origen == null || origen <= 0) return response.BuildResponse<TasaCambio>(this, null, parameterName: nameof(origen));
            if (destino == null || destino <= 0) return response.BuildResponse<TasaCambio>(this, null, parameterName: nameof(destino));

            try
            {
                var resultado = await negocio.ObtenerTasaActual(origen.Value, destino.Value);


                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                return response.BuildResponse<TasaCambio>(this, null, exception: ex);
            }

        }

        /// <summary>
        /// obtiene la tasa de cambio entre dos monedas en una fecha específica
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpGet("tasacambio/porfecha/{origen}/{destino}/{fecha}")]
        public async Task<ActionResult<ApiResponse<TasaCambio>>> GetExchangeByDate(int? origen, int? destino, DateTime? fecha)
        {
            if (origen == null || origen <= 0) return response.BuildResponse<TasaCambio>(this, null, parameterName: nameof(origen));
            if (destino == null || destino <= 0) return response.BuildResponse<TasaCambio>(this, null, parameterName: nameof(destino));
            if (fecha == null) return response.BuildResponse<TasaCambio>(this, null, parameterName: nameof(fecha));

            try
            {
                var resultado = await negocio.ObtenerTasaPorFecha(origen.Value, destino.Value, fecha.Value);



                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                return response.BuildResponse<TasaCambio>(this, null, exception: ex);
            }

        }

        /// <summary>
        /// obtiene el historial de tasas de cambio entre dos monedas en un rango de fechas
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpGet("tasacambio/historial/{origen}/{destino}/{fechainicial}/{fechafin}")]
        public async Task<ActionResult<ApiResponse<List<TasaCambio>>>> GetHistoryExchange(int? origen, int? destino, DateTime? fechainicial, DateTime? fechafin)
        {
            if (origen == null || origen <= 0) return response.BuildResponse<List<TasaCambio>>(this, null, parameterName: nameof(origen));
            if (destino == null || destino <= 0) return response.BuildResponse<List<TasaCambio>>(this, null, parameterName: nameof(destino));
            if (fechainicial == null) return response.BuildResponse<List<TasaCambio>>(this, null, parameterName: nameof(fechainicial));
            if (fechafin == null) return response.BuildResponse<List<TasaCambio>>(this, null, parameterName: nameof(fechafin));

            try
            {
                var resultado = await negocio.ListarHistorial(origen.Value, destino.Value, fechainicial.Value, fechafin.Value);

              return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                return response.BuildResponse<List<TasaCambio>>(this, null, exception: ex);
            }

        }
        #endregion
    }
}
