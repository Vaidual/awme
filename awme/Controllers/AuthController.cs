using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {
            if (await _userService.CheckIfUserExistsByEmail(request.Email))
            {
                return StatusCode(409, $"This email is already taken.");
            }
            VerificationController.CreatePasswordHash(
                request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Role = Role.User
            };
            user = await _userService.AddUser(user);
            string token = CreateToken(user);
            return CreatedAtRoute("GetUserById", new { id = user.Id}, new { user, token});
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            var verifiedUser = await VerificationController.VerifyUserAsync(request, _userService);
            if (verifiedUser == null)
            {
                return Unauthorized("Wrong email or password");
            }
            string token = CreateToken(verifiedUser);

            var cookiesOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(2),
                SameSite = SameSiteMode.None,
                Secure = true,
            };
            Response.Cookies.Append("refreshToken", token, cookiesOptions);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JwtConfig:Secret"]!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
