using Newtonsoft.Json;

namespace NetCore.Helpers.Exceptions
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new
            {
                statusCode = StatusCode,
                message = Message
            });
        }
    }
}