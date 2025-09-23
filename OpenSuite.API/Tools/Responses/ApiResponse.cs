using System.Net.NetworkInformation;

namespace OpenSuite.API.Tools.Responses
{


    public enum ResponseStatus
    {
        Failure = 0,
        Success = 1,
        ValidationError = 0
    }

    /// <summary>
    /// Respuesta estándar para las APIs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Estado de la respuesta
        /// </summary>
        public ResponseStatus Status { get; set; }  // Éxito, fallo, validación

        /// <summary>
        /// Código de la respuesta
        /// </summary>
        public int Code { get; set; }               // Código HTTP o interno

        /// <summary>
        /// Datos de la respuesta
        /// </summary>
        public T Data { get; set; }                 // Objeto o lista

        /// <summary>
        /// Mensaje de error si aplica
        /// </summary>
        public string ErrorMessage { get; set; }    // Mensaje de error

        /// <summary>
        /// Marca de tiempo de la respuesta
        /// </summary>
        public DateTime DateAt { get; set; }     // Fecha/hora de respuesta

        /// <summary>
        /// Constructor para éxito
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        public ApiResponse(T data, int code = 200)
        {
            Status = ResponseStatus.Success;
            Code = code;
            Data = data;
            ErrorMessage = null;
            DateAt = DateTime.Now;
        }

        /// <summary>
        /// Constructor para fallo
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="code"></param>
        /// <param name="status"></param>
        public ApiResponse(string errorMessage, int code = 500, ResponseStatus status = ResponseStatus.Failure)
        {
            Status = status;
            Code = code;
            Data = default;
            ErrorMessage = errorMessage;
            DateAt = DateTime.Now;
        }
    }
}
