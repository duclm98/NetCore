using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using NetCore.Data.Data;
using NetCore.Data.Models;
using NetCore.API.Dto;

namespace NetCore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly NetCoreDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(NetCoreDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto registerDto)
        {
            var u = await _context.Users.SingleOrDefaultAsync(item => item.Username == registerDto.Username);
            if (u != null)
            {
                return BadRequest("Username is already existed!");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            User newUser = new User { Username = registerDto.Username, Password = registerDto.Password };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return registerDto;
        }
    }
}
