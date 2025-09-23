using Microsoft.AspNetCore.Mvc;

using Entidades.Catalogos;
using Negocio.Modulos.Catalogos;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Controllers.Catalogos
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con países.
    /// </summary>
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class PaisesController : ControllerBase
    {

        private readonly CatalogosServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// Constructor del controlador de países.
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public PaisesController(CatalogosServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }

        #region "Paises y ciudades"
        /// <summary>
        /// obtener todos los paises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Pais>>>> GetAllCountries()
        {
            try
            {
                var resultado = await negocio.ListarPaises();
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Pais>>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// obtener un pais por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Pais>>> GetCountryByID(int? id)
        {
            // Valida el parámetro empresaID
            if (id == null || id <= 0)
                return response.BuildResponse<Pais>(this, null, parameterName: nameof(id));

            try
            {
                // llama a negocio para obtener el pais por ID
                var resultado = await negocio.ObtenerPais(id);


                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Pais>(this, null, exception: ex);
            }
        }



        /// <summary>
        /// obtener todas las ciudades de un pais
        /// </summary>
        /// <param name="paisID"></param>
        /// <returns></returns>
        [HttpGet("{paisID}/ciudades")]
        public async Task<ActionResult<ApiResponse<List<Ciudad>>>> GetAllCities(int? paisID)
        {
            if (paisID == null || paisID <= 0) 
                return response.BuildResponse<List<Ciudad>>(this, null, parameterName: nameof(paisID));
            try
            {
                var resultado = await negocio.ListarCiudades(paisID.Value);

                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Ciudad>>(this, null, exception: ex);
            }
        }


        /// <summary>
        /// obtener una ciudad por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{paisID}/ciudades/{ciudadID}")]
        public async Task<ActionResult<ApiResponse<Ciudad>>> GetCitytByID(int? paisID, int? ciudadID)
        {
            // Valida el parámetro empresaID
            if (paisID == null || paisID <= 0) return response.BuildResponse<Ciudad>(this, null, parameterName: nameof(paisID));
            if (ciudadID == null || ciudadID <= 0) return response.BuildResponse<Ciudad>(this, null, parameterName: nameof(ciudadID));

            try
            {
                // llama a negocio para obtener el pais por ID
                var resultado = await negocio.ObtenerCiudad(paisID.Value, ciudadID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Ciudad>(this, null, exception: ex);
            }
        }
        #endregion
    }
}
