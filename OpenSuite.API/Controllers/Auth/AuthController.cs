using Azure;
using Entidades.Seguridad.Auth;
using Microsoft.AspNetCore.Mvc;
using OpenSuite.API.Tools.Responses;
using System.Net;

namespace OpenSuite.API.Controllers.Auth
{

    [ApiController]
    [Route("api/opensuite/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly Negocio.Modulos.Seguridad.Auth.AuthServicios _authServicios;

        private readonly IResponseService response;


        public AuthController(Negocio.Modulos.Seguridad.Auth.AuthServicios authServicios, IResponseService responseService)
        {
            _authServicios = authServicios;
            response = responseService;
        }




        /// <summary>
        /// endpoint para autenticar un usuario y obtener un token JWT junto con sus roles y permisos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<Entidades.Seguridad.Authentication.Auth>>> Login([FromBody] Login request)
        {
            try
            {
                var (Success, Token, Roles, Permisos, Error) = await _authServicios.ObtenerUsuario(request.Username, request.Password);


                if (!Success)
                    return response.BuildResponse<Entidades.Seguridad.Authentication.Auth>(this, null, HttpStatusCode.Unauthorized, Error);



                return response.BuildResponse<Entidades.Seguridad.Authentication.Auth>(this, new Entidades.Seguridad.Authentication.Auth
                {
                    Token = Token!,
                    Perfiles = Roles,
                    Permisos = Permisos
                });
            }
            catch (Exception ex)
            {

                return response.BuildResponse<Entidades.Seguridad.Authentication.Auth>(this, null, exception: ex);
            }
        }
    }
}
