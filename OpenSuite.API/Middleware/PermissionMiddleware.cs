using Entidades.Seguridad.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Modulos.Seguridad.Permisos;
using OpenSuite.API.Tools.Responses;
using System.Net;
using System.Threading.Tasks;

namespace OpenSuite.API.Middleware
{
    /// <summary>
    /// Middleware para verificar permisos de usuario en base a claims y permisos almacenados en la base de datos.
    /// </summary>
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// metodo invoke del middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            // Resolver el servicio scoped dentro del request
            var response = context.RequestServices.GetRequiredService<IResponseService>();

            // Ahora puedes usar response normalmente
            var endpoint = context.GetEndpoint();
            var authorizeMetadata = endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Authorization.IAuthorizeData>();

            if (authorizeMetadata != null)
            {
                // Verificar si el usuario está autenticado
                if (!(context.User.Identity?.IsAuthenticated ?? false))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var result = response.BuildResponse<object>(
                        controller: new EmptyControllerWrapper(context),
                        data: null,
                        forcedStatus: System.Net.HttpStatusCode.Unauthorized,
                        errorMessage: "No tienes permiso para esta acción"
                    );
                    return;
                }

                // Obtener el servicio de permisos
                var permisos = context.RequestServices.GetRequiredService<PermisosServicios>();
                var path = context.Request.Path.Value?.ToLower();
                var method = context.Request.Method.ToUpper();

                var accion = await permisos.VerificarPermiso(path, method);

                // Si se requiere una acción específica, verificar si el usuario tiene el permiso
                if (accion != null && !context.User.HasClaim("Accion", accion.Permiso))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";


                    //var Result = response.BuildResponse<List<object>>(new EmptyControllerWrapper(context), null, HttpStatusCode.Unauthorized, "Permiso no autorizado");


                    var result = response.BuildResponse<object>(
                        controller: new EmptyControllerWrapper(context),
                        data: null,
                        forcedStatus: System.Net.HttpStatusCode.Forbidden,
                        errorMessage: "No tienes permiso para esta acción"
                    );

                    if (result.Result is ObjectResult objectResult)
                    {
                        var apiResponse = objectResult.Value; 
                        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(apiResponse));
                    }

                    return;
                }
            }

            await _next(context);
        }

        // Helper para usar ResponseService sin un ControllerBase real
        private class EmptyControllerWrapper : ControllerBase
        {
            public EmptyControllerWrapper(HttpContext context)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = context
                };
            }
        }
    }

}