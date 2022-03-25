namespace NetCore.Helpers.Responses
{
    public class CustomResponse
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "Successful";
        public object Result { get; set; } = null;

        public CustomResponse(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public CustomResponse(int statusCode, string message, object result)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;
        }
    }
}