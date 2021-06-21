using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using NetCore.API.Methods;
using NetCore.API.Repositories;

namespace NetCore.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public AuthMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserRepository userRepo, IAuthMethod authMethod)
        {
            string[] ignorePath = { "/api/auth/register", "/api/auth/login" };

            if (!ignorePath.Contains(httpContext.Request.Path.Value))
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;

                var accessToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (accessToken == null)
                {
                    await httpContext.Response.WriteAsync("Thiếu access token!");
                    return;
                }

                var id = authMethod.ValidateJSONWebToken(accessToken, _config["Jwt:AccessTokenSecret"], _config["Jwt:Issuer"], _config["Jwt:Audience"]);

                if (id == null)
                {
                    await httpContext.Response.WriteAsync("Access token không hợp lệ hoặc đã hết hạn!");
                    return;
                }

                var user = await userRepo.Detail((long)id);
                if (user == null)
                {
                    await httpContext.Response.WriteAsync("Thông tin chứa trong access token không hợp lệ!");
                    return;
                }

                httpContext.Items["user"] = user;
            }

            await _next(httpContext);
        }
    }
}
