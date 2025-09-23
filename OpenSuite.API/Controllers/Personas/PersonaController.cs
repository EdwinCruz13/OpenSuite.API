using Entidades.Finanzas.PlanCuentas;
using Entidades.Personas;
using Entidades.Seguridad.Usuarios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


using Negocio.Modulos.Personas;
using OpenSuite.API.Tools.Responses;
using System.Net;
using System.Xml;

namespace OpenSuite.API.Controllers.Personas
{
    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonasServicios negocio;
        private readonly IResponseService response;

        /// <summary>
        /// constructor de controlador de personas
        /// </summary>
        /// <param name="_negocio"></param>
        /// <param name="responseService"></param>
        public PersonaController(PersonasServicios _negocio, IResponseService responseService)
        {
            negocio = _negocio;
            response = responseService;
        }


        /// <summary>
        /// Listar todas las personas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Persona>>>> GetAll()
        {
            try
            {
                var resultado = await negocio.ListarPersonas();
                return response.BuildResponse(this, resultado);   
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<List<Persona>>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// Obtener persona por ID
        /// </summary>
        /// <param name="PersonaID"></param>
        /// <returns></returns>
        [HttpGet("{PersonaID}")]
        public async Task<ActionResult<ApiResponse<Persona>>> GetByID(int? PersonaID)
        {
            if (PersonaID == null)  return response.BuildResponse<Persona>(this, data: null, parameterName: "PersonaID");
            try
            {
                var resultado = await negocio.ObternerPersona(PersonaID.Value);
                return response.BuildResponse(this, resultado);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Persona>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// Crear un nuevo usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Persona>>> Save([FromBody] PersonaDTO dto)
        {
            if (dto == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.PersonaID));
            if (dto.Email == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.Email));
            if (dto.Identificacion == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.Identificacion));

            try
            {
                // Crear la persona
                var created = await negocio.CrearPersona(dto);

                return CreatedAtAction(
                    nameof(GetByID),
                    new { PersonaID = created?.PersonaID },
                    new ApiResponse<Persona>(created, 201)
                );
            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Persona>(this, data: null, exception: ex);
            }
        }

        /// <summary>
        /// Actualizar una persona existente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Persona>>> Update(int? id, [FromBody] PersonaDTO dto)
        {
            if (id <= 0 || id == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(id));
            if (dto == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto));
            if (dto.PersonaID <= 0) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.PersonaID));
            if (dto.Email == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.Email));
            if (dto.Identificacion == null) return response.BuildResponse<Persona>(this, null, parameterName: nameof(dto.Identificacion));

            try
            {
                // Actualizar la persona
                var resultado = await negocio.ActualizarPersona(dto);

                return response.BuildResponse<Persona>(this, null, forcedStatus: HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                // En caso de error, retorna una respuesta de error genérica
                return response.BuildResponse<Persona>(this, data: null, exception: ex);
            }
        }
    }
}
