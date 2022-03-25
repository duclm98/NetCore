using Newtonsoft.Json;

namespace NetCore.Helpers.Responses
{
    public class ResponseDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new
            {
                statusCode = StatusCode,
                message = Message,
                Result = Result
            });
        }
    }
}