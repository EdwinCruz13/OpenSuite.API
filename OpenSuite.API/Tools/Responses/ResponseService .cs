using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;

namespace OpenSuite.API.Tools.Responses
{
    /// <summary>
    /// Servicio para generar respuestas estándar de API
    /// </summary>
    public class ResponseService : IResponseService
    {


        public ActionResult<ApiResponse<T>> BuildResponse<T>(
            ControllerBase controller,
            T? data,
            HttpStatusCode? forcedStatus = null,
            string? errorMessage = null,
            string? parameterName = null,
            Exception? exception = null)
        {
            // la lógica interna
            var apiResponse = BuildApiResponse(data, forcedStatus, errorMessage, parameterName, exception);

            // Retornamos como ActionResult cuando se llama desde un controlador
            return controller.StatusCode(apiResponse.Code, apiResponse);
        }

        public ApiResponse<T> BuildApiResponse<T>(
            T? data,
            HttpStatusCode? forcedStatus = null,
            string? errorMessage = null,
            string? parameterName = null,
            Exception? exception = null)
        {
            // Error por parámetro inválido
            if (!string.IsNullOrEmpty(parameterName))
            {
                return new ApiResponse<T>(
                    $"El parámetro '{parameterName}' es inválido o no fue proporcionado.",
                    (int)HttpStatusCode.BadRequest,
                    ResponseStatus.ValidationError
                );
            }

            // Error por excepción
            if (exception != null)
            {
                return new ApiResponse<T>(
                    $"Error interno del servidor. Detalles: {exception.Message}",
                    (int)HttpStatusCode.InternalServerError,
                    ResponseStatus.Failure
                );
            }

            // Estados forzados
            if (forcedStatus.HasValue)
            {
                return forcedStatus.Value switch
                {
                    HttpStatusCode.Created => new ApiResponse<T>(data!, (int)HttpStatusCode.Created),
                    HttpStatusCode.NoContent => new ApiResponse<T>(data: default!, code: 204),
                    HttpStatusCode.Unauthorized => new ApiResponse<T>(
                        errorMessage ?? "No autorizado", 401, ResponseStatus.Failure),
                    HttpStatusCode.Forbidden => new ApiResponse<T>(
                        errorMessage ?? "Acceso denegado", 403, ResponseStatus.Failure),
                    _ => new ApiResponse<T>(data!, (int)forcedStatus.Value),
                };
            }

            // Si el objeto es null → NotFound
            if (data == null)
            {
                string typeName = typeof(T).Name;
                return new ApiResponse<T>(
                    $"El recurso de tipo '{typeName}' no fue encontrado.",
                    (int)HttpStatusCode.NotFound,
                    ResponseStatus.Failure
                );
            }

            // Si es lista vacía → NoContent
            if (data is IEnumerable enumerable && !enumerable.Cast<object>().Any())
            {
                return new ApiResponse<T>(
                    data: default!,
                    code: (int)HttpStatusCode.NoContent
                );
            }

            // OK → con datos
            return new ApiResponse<T>(data, (int)HttpStatusCode.OK);
        }




    //    /// <summary>
    //    /// Construye una respuesta estándar de API en base al objeto recibido.
    //    /// </summary>
    //    public ActionResult<ApiResponse<T>> BuildResponse<T>(
    //        ControllerBase controller, // el controlador que llama al servicio, necesario para retornar ActionResult, ademas el program.cs no tiene ni puta idea de como inyectarlo
    //        T? data, // el objeto de datos a evaluar
    //        HttpStatusCode? forcedStatus = null, // estado HTTP forzado (opcional)
    //        string? errorMessage = null, // mensaje de error personalizado (opcional)
    //        string? parameterName = null, // nombre del parámetro inválido (opcional)
    //        Exception? exception = null) // excepción capturada (opcional)
    //    {
    //        // Error por parámetro inválido
    //        if (!string.IsNullOrEmpty(parameterName))
    //        {
    //            return controller.BadRequest(new ApiResponse<T>(
    //                $"El parámetro '{parameterName}' es inválido o no fue proporcionado.",
    //                (int)HttpStatusCode.BadRequest,
    //                ResponseStatus.ValidationError
    //            ));
    //        }

    //        // Error por excepción
    //        if (exception != null)
    //        {
    //            return controller.StatusCode((int)HttpStatusCode.InternalServerError,
    //                new ApiResponse<T>(
    //                    $"Error interno del servidor. Detalles: {exception.Message}",
    //                    (int)HttpStatusCode.InternalServerError,
    //                    ResponseStatus.Failure
    //                ));
    //        }

    //        // Estados forzados
    //        if (forcedStatus.HasValue)
    //        {
    //            switch (forcedStatus.Value)
    //            {
    //                case HttpStatusCode.Created:
    //                    return controller.StatusCode((int)HttpStatusCode.Created,
    //                        new ApiResponse<T>(data!, (int)HttpStatusCode.Created));

    //                case HttpStatusCode.NoContent:
    //                    return controller.StatusCode(
    //                        (int)HttpStatusCode.OK,
    //                        new ApiResponse<T>( data: data!,code: 204)
    //                    );


    //                case HttpStatusCode.Unauthorized:
    //                    return controller.StatusCode(
    //                        (int)HttpStatusCode.Unauthorized,
    //                        new ApiResponse<T>(errorMessage: errorMessage, code: 401)
    //                    );
    //                //return controller.NoContent();

    //                default:
    //                    return controller.StatusCode((int)forcedStatus.Value,
    //                        new ApiResponse<T>(data!, (int)forcedStatus.Value));
    //            }
    //        }

    //        // Si el objeto es null → NotFound
    //        if (data == null)
    //        {
    //            string typeName = typeof(T).Name;
    //            return controller.NotFound(new ApiResponse<T>(
    //                $"El recurso de tipo '{typeName}' no fue encontrado.",
    //                (int)HttpStatusCode.NotFound,
    //                ResponseStatus.Failure
    //            ));
    //        }

    //        // Si es lista vacía → NoContent
    //        if (data is IEnumerable enumerable && !enumerable.Cast<object>().Any())
    //        {
    //            return controller.StatusCode(
    //                (int)HttpStatusCode.OK,
    //                new ApiResponse<T>(
    //                    data: default,
    //                    code: (int)HttpStatusCode.NoContent
    //                )
    //            );
    //        }

    //        // OK → con datos
    //        return controller.Ok(new ApiResponse<T>(data, (int)HttpStatusCode.OK));
    //    }
    }
}
