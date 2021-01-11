using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateUser model);
        ApplicationUser GetById(string id);
    }

    public class UserService : IUserService
    {
        private readonly WePartyDBContext _context;

        public UserService(WePartyDBContext context)
        {
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateUser userCredentials)
        {
            var user = FindByUsernameOrEmail(userCredentials);

            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            LoginUser loginResponseUser = new LoginUser
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                AccessToken = token
            };
            return new AuthenticateResponse
            {
                User = loginResponseUser
            };
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        private ApplicationUser FindByUsernameOrEmail(AuthenticateUser userCredentials)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName == userCredentials.Username);
            if (user == null)
                return _context.Users.FirstOrDefault(user => user.Email== userCredentials.Username);
            return user;
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("b6)Xad<#W!bW3Vdg");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}