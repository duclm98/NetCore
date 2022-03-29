using Newtonsoft.Json;

namespace NetCore.Helpers.Exceptions
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public override string ToString()
        {
            if (Result == null)
                return JsonConvert.SerializeObject(new
                {
                    statusCode = StatusCode,
                    message = Message
                });
            return JsonConvert.SerializeObject(new
            {
                statusCode = StatusCode,
                message = Message,
                result = Result
            });
        }
    }
}