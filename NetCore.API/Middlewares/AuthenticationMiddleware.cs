using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetCore.API.SubServices;
using NetCore.Data.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.API.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserSubService userSubService, UnitOfWork unitOfWork)
        {
            string[] ignorePath =
            {
                "/auth/login"
            };

            if (!ignorePath.Contains(httpContext.Request.Path.Value))
            {
                var accessToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (accessToken == null)
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Thiếu access token!");
                    return;
                }

                var userId = userSubService.ValidateJsonWebToken(accessToken);

                if (userId == null)
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Access token không hợp lệ hoặc đã hết hạn!");
                    return;
                }

                var userQueryable = unitOfWork.UserRepository.Queryable
                        .Where(x => x.UserId == userId);

                if (!await userQueryable.AnyAsync())
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Không xác thực bảo mật!");
                    return;
                }

                httpContext.Items["userId"] = userId;
            }

            await _next(httpContext);
        }
    }
}
