using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Authenticate.Models;
using Microsoft.IdentityModel.Tokens;

namespace Application.Authenticate
{
    public class UserService
    {
        public User Authenticate(string username, string password)
        {
            //var user = Context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

            User user = new User();

            if (username == "admin" && password == "admin")
            {
                user.Username = username;
                user.Password = password;
                user.Role = "admin";
            }
            else if (username == "user" && password == "user")
            {
                user.Username = username;
                user.Password = password;
                user.Role = "user";
            }
            else
                user = null;


            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("Store", user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}
