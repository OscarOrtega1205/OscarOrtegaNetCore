using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OscarOrtegaMartinez.Models.Common;
using OscarOrtegaMartinez.Models.Request;
using OscarOrtegaMartinez.Models.Response;
using OscarOrtegaMartinez.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using OscarOrtegaMartinez.Tools;
using OscarOrtegaMartinez.Models.EntityModels;

namespace OscarOrtegaMartinez.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public Response Auth(AuthRequest authRequest)
        {
            var response = new UserResponse();
            using (var db = new OscarOrtegaDBContext())
            {
                string password = Encrypt.GetSHA256(authRequest.Password);
                var user = db.User.Where(u => u.UserName.Equals(authRequest.UserName) && u.Password.Equals(password)).FirstOrDefault();

                if (null == user) return new Response { Success = false, Data =  response, Message = "User or Password incorrect" };

                response.UserName = user.UserName;
                response.Token = GetToken(user);
            }

            return new Response { Success = true, Data = response, Message = string.Empty };
        }

        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName)
                    }
               ),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                
            };
            
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

    }
}
