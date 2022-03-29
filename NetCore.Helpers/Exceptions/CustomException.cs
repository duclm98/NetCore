using Newtonsoft.Json.Linq;
using System;

namespace NetCore.Helpers.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public object Result { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public CustomException(int statusCode, string message, object result = null)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.Result = result;
        }

        public CustomException(int statusCode, Exception inner)
            : this(statusCode, inner.ToString()) { }

        public CustomException(int statusCode, JObject errorObject)
            : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }
    }
}