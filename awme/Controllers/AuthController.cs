﻿using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Microsoft.AspNetCore.Authorization;

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

            return Ok(token);
        }

        [HttpDelete("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            Console.Write(111);
            HttpContext.Response.Cookies.Delete("accessToken",
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    IsEssential = true
                }
            );
            return Ok();
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
            };
            var roles = user.Role.ToString().Split(',');
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JwtConfig:Secret"]!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            HttpContext.Response.Cookies.Append("accessToken", jwt,
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    IsEssential = true
                });
            return jwt;
        }
    }
}
