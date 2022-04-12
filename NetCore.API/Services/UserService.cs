using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.API.Dto.Authentication;
using NetCore.API.SubServices;
using NetCore.Data.Repositories;
using NetCore.Helpers.Exceptions;
using NetCore.Helpers.Result;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.API.Services
{
    public interface IUserService
    {
        Task<IActionResult> Login(LoginCreateDto loginCreatedto);
    }

    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IUserSubService _userSubService;

        public UserService(IComponentContext componentContext)
        {
            _unitOfWork = componentContext.Resolve<UnitOfWork>();
            _userSubService = componentContext.Resolve<IUserSubService>();
        }

        public async Task<IActionResult> Login(LoginCreateDto loginCreatedto)
        {
            var user = await _unitOfWork.UserRepository.Queryable
                .Where(x => x.Username == loginCreatedto.Username)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new CustomException("Tên đăng nhập hoặc mật khẩu không chính xác", 401);

            var accessToken = _userSubService.GenerateJsonWebToken(user.UserId);

            return new CustomResult("Đăng nhập thành công", new
            {
                User = new
                {
                    user.UserId,
                    user.Username
                },
                AccessToken = accessToken
            });
        }
    }
}
