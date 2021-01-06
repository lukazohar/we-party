using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly WePartyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthorizationController(
            WePartyDBContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUser newUser)
        {
            var user = new ApplicationUser()
            {
                UserName = newUser.UserName
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            else
            {
                return BadRequest();
            }

            return newUser;
        }

        [HttpPost("token")]
        public async Task<ActionResult<LoginUser>> Login(RegisterUser userCredentials)
        {
            if (await AuthenticateUserCredentials(userCredentials))
            {
                var token = GenerateToken(userCredentials);

                if (token != null)
                {
                    if (userCredentials.Username != null)
                    {
                        var dbUser = _context.Users.FirstOrDefault(user => user.UserName== userCredentials.Username);
                        LoginUser user = new LoginUser()
                        {
                            Id = dbUser.Id,
                            Username = dbUser.UserName,
                            Email = dbUser.Email,
                            AccessToken = token,
                        };
                        return Ok(user);
                    }
                    else
                    {
                        var dbUser = _context.Users.FirstOrDefault(user => user.Email== userCredentials.Username);
                        LoginUser user = new LoginUser()
                        {
                            Id = dbUser.Id,
                            Username = dbUser.UserName,
                            Email = dbUser.Email,
                            AccessToken = token,
                        };
                        return Ok(user);
                    }
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [NonAction]
        public async Task<bool> AuthenticateUserCredentials(RegisterUser credentials)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = new Microsoft.AspNetCore.Identity.SignInResult();

            if (credentials.Username != null)
            {
                result = await _signInManager.PasswordSignInAsync(credentials.Username, credentials.Password, false, lockoutOnFailure: false);

                if (! result.Succeeded)
                {
                    var user = _context.Users.FirstOrDefault(user => user.Email == credentials.Username);
                    result = await _signInManager.PasswordSignInAsync(user.UserName, credentials.Password, false, lockoutOnFailure: false);
                }
            }

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [NonAction]
        public string GenerateToken(RegisterUser userCredentials)
        {
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(/* pozneje popravi z 'JWTSecret' iz okoljskih datotek */ "when done, set this key from environemnt variables"));
            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            if (userCredentials.Username != null) claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userCredentials.Username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(14), signingCredentials: credentials);

            var encodedResponse = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedResponse;
        }
    }
}

