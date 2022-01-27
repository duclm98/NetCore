using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NetCore.API.SubServices
{
    public interface IUserSubService
    {
        string GenerateJsonWebToken(int id);
        int? ValidateJsonWebToken(string token);
    }

    public class UserSubService : IUserSubService
    {
        private readonly IConfiguration _configuration;

        public UserSubService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJsonWebToken(int id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:AccessTokenSecret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("id", id.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                null,
                DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessTokenExpires"])),
                credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int? ValidateJsonWebToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, // có validate thời gian hết hạn
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:AccessTokenSecret"])),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return id;
            }
            catch
            {
                return null;
            }
        }
    }
}