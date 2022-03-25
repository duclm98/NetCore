using Newtonsoft.Json.Linq;
using System;

namespace NetCore.Helpers.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public CustomException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public CustomException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
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