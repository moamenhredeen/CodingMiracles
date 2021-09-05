using core.Entities;

namespace api.Utils
{
    public class Response<T>
    {
        private static readonly string FAILURE = "failure";
        
        public string Message { get; private  set; }
        public T Data { get; init; }

        public Response()
        {
            Message = FAILURE; 
        }
        public Response(string message)
        {
            Message = message; 
        }
        public Response(string message, T data)
        {
            Message = message;
            Data = data; 
        }

    }
}