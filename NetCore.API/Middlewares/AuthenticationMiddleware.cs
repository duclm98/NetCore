using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetCore.API.SubServices;
using NetCore.Data.Repositories;
using NetCore.Helpers.Exceptions;
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
                    throw new CustomException("Thiếu access token!", 401);

                var userId = userSubService.ValidateJsonWebToken(accessToken);

                if (userId == null)
                    throw new CustomException("Access token không hợp lệ hoặc đã hết hạn!", 401);

                var userQueryable = unitOfWork.UserRepository.Queryable
                        .Where(x => x.UserId == userId);

                if (!await userQueryable.AnyAsync())
                    throw new CustomException("Không xác thực bảo mật!", 401);

                httpContext.Items["userId"] = userId;
            }

            await _next(httpContext);
        }
    }
}
