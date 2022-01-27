using AutoWrapper.Wrappers;
using Microsoft.EntityFrameworkCore;
using NetCore.API.Dto.Authentication;
using NetCore.API.SubServices;
using NetCore.Data.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.API.Services
{
    public interface IUserService
    {
        Task<ApiResponse> Login(LoginCreateDto loginCreatedto);
    }

    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IUserSubService _userSubService;

        public UserService(UnitOfWork unitOfWork, IUserSubService userSubService)
        {
            _unitOfWork = unitOfWork;
            _userSubService = userSubService;
        }

        public async Task<ApiResponse> Login(LoginCreateDto loginCreatedto)
        {
            var user = await _unitOfWork.UserRepository.Queryable
                .Where(x => x.Username == loginCreatedto.Username)
                .FirstOrDefaultAsync();
            if (user == null)
                return new ApiResponse("Tên đăng nhập hoặc mật khẩu không chính xác", null, 409);

            //var isMatch = BCrypt.Net.BCrypt.Verify(loginCreatedto.Password, user.Password);
            //if (!isMatch)
            //    return new ApiResponse("Tên đăng nhập hoặc mật khẩu không chính xác", null, 409);

            var accessToken = _userSubService.GenerateJsonWebToken(user.UserId);

            return new ApiResponse("Đăng nhập thành công", new
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
