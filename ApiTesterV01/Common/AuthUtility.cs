using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesterV01.Common
{
    public class AuthUtility
    {
        private IConfiguration _configuration;
        public AuthUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateNewToken(Guid userGuid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("TokenKey"));
            var tokenTimeOut = _configuration.GetValue<int>("TokenTimeOut");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("userGuid", userGuid.ToString()),
                    //  new Claim("TimeOut-Minute", tokenTimeOut.ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(tokenTimeOut),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }
    }
}
