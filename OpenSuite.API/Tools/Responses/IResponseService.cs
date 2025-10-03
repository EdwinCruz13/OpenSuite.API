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

    }
}
