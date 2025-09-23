using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OpenSuite.API.Tools.Responses
{
    public interface IResponseService
    {
        /// <summary>
        /// Construye una respuesta inteligente en base al objeto recibido.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="forcedStatus"></param>
        /// <param name="errorMessage"></param>
        /// <param name="parameterName"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        ActionResult<ApiResponse<T>> BuildResponse<T>(ControllerBase controller, T? data, HttpStatusCode? forcedStatus = null, string? errorMessage = null, string? parameterName = null, Exception? exception = null);



        //ApiResponse<T> Success<T>(T data, int code = 200);
        //ApiResponse<T> Failure<T>(string? errorMessage = null, int code = 500);
        //ApiResponse<T> ValidationError<T>(string? errorMessage = null, int code = 400);
        //ApiResponse<T> ResourceNotFound<T>(string? errorMessage = null, int code = 404);
        //ApiResponse<T> Created<T>(T data, int code = 201);
    }
}
