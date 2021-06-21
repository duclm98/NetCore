﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.API.Methods
{
    public interface IAuthMethod
    {
        public string GenenateJSONWebToken(long id, string secretKey, double expires, string issuer, string audience);
        public long? ValidateJSONWebToken(string token, string secretKey, string issuer, string audience);
        public long? DecodeJSONWebToken(string token, string secretKey, string issuer, string audience);
    }

    public class AuthMethod: IAuthMethod
    {
        public string GenenateJSONWebToken(long id, string secretKey, double expires, string issuer, string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("id", id.ToString())
            };

            var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    notBefore: null,
                    expires: DateTime.Now.AddMinutes(expires),
                    signingCredentials: credentials
                  );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public long? ValidateJSONWebToken(string token, string secretKey, string issuer, string audience)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return id;
            }
            catch
            {
                return null;
            }
        }

        public long? DecodeJSONWebToken(string token, string secretKey, string issuer, string audience)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return id;
            }
            catch
            {
                return null;
            }
        }
    }
}
