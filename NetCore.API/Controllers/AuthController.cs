using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using NetCore.Data.Models;
using NetCore.API.Methods;
using NetCore.API.Dto;
using NetCore.API.Repositories;

namespace NetCore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        private readonly IAuthMethod _authMethod;

        public AuthController(IConfiguration config, IUserRepository userRepo, IAuthMethod authMethod)
        {
            _config = config;
            _userRepo = userRepo;
            _authMethod = authMethod;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto registerDto)
        {
            var u = await _userRepo.GetUser(registerDto.Username);
            if (u != null)
            {
                return BadRequest("Tên đăng nhập đã tồn tại!");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            User newUser = new User { Username = registerDto.Username, Password = passwordHash };

            var createUser = await _userRepo.CreateUser(newUser);
            if (!createUser)
            {
                return BadRequest("Lỗi không xác định");
            }

            return registerDto;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginResDto>> Login(LoginReqDto loginReqDto)
        {
            var u = await _userRepo.GetUser(loginReqDto.Username);
            if (u == null)
            {
                return NotFound("Tên đăng nhập không tồn tại!");
            }

            bool verified = BCrypt.Net.BCrypt.Verify(loginReqDto.Password, u.Password);
            if (!verified)
            {
                return BadRequest("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }

            LoginResDto loginResDto = new LoginResDto();

            loginResDto.AccessToken = _authMethod.GenenateJSONWebToken(u.ID, _config["Jwt:AccessTokenSecret"], Convert.ToDouble(_config["Jwt:AccessTokenExpires"]), _config["Jwt:Issuer"], _config["Jwt:Audience"]);

            var createNewRefreshToken = false;

            if (u.RefreshToken == null)
            {
                createNewRefreshToken = true;
            }
            else
            {
                var validateRefreshToken = _authMethod.ValidateJSONWebToken(u.RefreshToken, _config["Jwt:RefreshTokenSecret"], _config["Jwt:Issuer"], _config["Jwt:Audience"]);
                if (validateRefreshToken == null)
                {
                    createNewRefreshToken = true;
                }
            }

            if (createNewRefreshToken == true)
            {
                var refreshToken = _authMethod.GenenateJSONWebToken(u.ID, _config["Jwt:RefreshTokenSecret"], Convert.ToDouble(_config["Jwt:RefreshTokenExpires"]), _config["Jwt:Issuer"], _config["Jwt:Audience"]);
                u.RefreshToken = refreshToken;

                var updateUser = await _userRepo.UpdateUser(u);
                if (!updateUser)
                {
                    return BadRequest("Lỗi không xác định!");
                }
            }

            loginResDto.RefreshToken = u.RefreshToken;
            loginResDto.User = new UserDto { Username = u.Username };

            return Ok(loginResDto);
        }

        [Route("refresh-token")]
        [HttpPost]
        public async Task<ActionResult<LoginResDto>> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(accessToken == null)
            {
                return BadRequest("Thiếu access token!");
            }

            var id = _authMethod.DecodeJSONWebToken(accessToken, _config["Jwt:AccessTokenSecret"], _config["Jwt:Issuer"], _config["Jwt:Audience"]);
            if (id == null)
            {
                return BadRequest("Access token không hợp lệ!");
            }

            var u = await _userRepo.Detail((long)id);
            if (u == null)
            {
                return BadRequest("Thông tin chứa trong access token không hợp lệ!");
            }

            if(u.RefreshToken == null)
            {
                return BadRequest("Refresh token không tồn tại, cần đăng nhập lại!");
            }

            var idRF = _authMethod.ValidateJSONWebToken(refreshTokenDto.RefreshToken, _config["Jwt:RefreshTokenSecret"], _config["Jwt:Issuer"], _config["Jwt:Audience"]);
            if(idRF == null)
            {
                return BadRequest("Refresh token không hợp lệ hoặc đã hết hạn, cần đăng nhập lại!");
            }

            if(refreshTokenDto.RefreshToken != u.RefreshToken || id != idRF)
            {
                return BadRequest("Refresh token không hợp lệ!");
            }

            var newAccessToken = _authMethod.GenenateJSONWebToken(u.ID, _config["Jwt:AccessTokenSecret"], Convert.ToDouble(_config["Jwt:AccessTokenExpires"]), _config["Jwt:Issuer"], _config["Jwt:Audience"]);

            LoginResDto loginResDto = new LoginResDto
            {
                AccessToken = newAccessToken,
                RefreshToken = refreshTokenDto.RefreshToken,
                User = new UserDto { Username = u.Username }
            };

            return Ok(loginResDto);
        }

        [Route("test-auth")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> TestAuth()
        {
            var user = (User)HttpContext.Items["user"];
            UserDto userDto = new UserDto { Username = user.Username };
            return Ok(userDto);
        }
    }
}
