using Microsoft.AspNetCore.Mvc;
using NetCore.API.Dto.Authentication;
using NetCore.API.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace NetCore.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [SwaggerOperation(Summary = "Đăng nhập")]
        [HttpPost("login")]
        public async Task<IActionResult> Add([FromBody] LoginCreateDto loginCreatedto)
        {
            return await _userService.Login(loginCreatedto);
        }
    }
}