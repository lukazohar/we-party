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
        public async Task<ActionResult<string>> Login(User userCredentials)
        {
            if (await AuthenticateUserCredentials(userCredentials))
            {
                var token = GenerateToken(userCredentials);

                if (token != null)
                {
                    return Ok(token);
                } else
                {
                    return StatusCode(500);
                }
            } else
            {
                return Unauthorized();
            }
        }

        public async Task<bool> AuthenticateUserCredentials(User credentials)
        {
            var result = await _signInManager.PasswordSignInAsync(credentials.Username, credentials.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public TokenResponse GenerateToken(User userCredentials)
        {
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(/* pozneje popravi z 'JWTSecret' iz okoljskih datotek */ "when done, set this key from environemnt variables"));
            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userCredentials.Username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, userCredentials.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(14), signingCredentials: credentials);

            TokenResponse encodedResponse = new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = token.ValidTo
            };

            return encodedResponse;
        }
    }
}

