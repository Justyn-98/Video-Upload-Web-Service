using API.Responses;
using API.Responses.Messages;
using System.Collections.Generic;


namespace API.ServiceResponses
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

        public IMessage Message { get; set; }

        private ServiceResponse(T responseData, bool success, IMessage message)
        {
            Message = message;
            Success = success;
            Data = responseData;
        }

        public static ServiceResponse<T> Ok(T data, IMessage message) => new ServiceResponse<T>(data, true, message);
        public static ServiceResponse<T> Ok(T data) => new ServiceResponse<T>(data, true, default);
        public static ServiceResponse<T> Ok( IMessage message) => new ServiceResponse<T>(default, true, message);
        public static ServiceResponse<T> Ok() => new ServiceResponse<T>(default, true, default);

        public static ServiceResponse<T> Error(T data, IMessage message) => new ServiceResponse<T>(data, false, message);
        public static ServiceResponse<T> Error(T data) => new ServiceResponse<T>(data, false, default);
        public static ServiceResponse<T> Error(IMessage message) => new ServiceResponse<T>(default, false, message);
        public static ServiceResponse<T> Error() => new ServiceResponse<T>(default, false, default);

    }
}
