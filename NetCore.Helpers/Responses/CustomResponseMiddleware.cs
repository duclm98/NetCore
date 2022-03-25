using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace NetCore.Helpers.Responses
{
    public class CustomResponseMiddleware
    {
        private readonly RequestDelegate next;

        public CustomResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //await HandleResponseAsync(context, ex);
        }

        private Task HandleResponseAsync(HttpContext context, CustomResponse response)
        {
            context.Response.ContentType = "application/json";
            string result = new ResponseDetail()
            {
                Message = response.Message,
                StatusCode = response.StatusCode,
                Result = response.Result,
            }.ToString();
            context.Response.StatusCode = response.StatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}