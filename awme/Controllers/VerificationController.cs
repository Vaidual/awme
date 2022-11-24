using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace awme.Controllers
{
    public static class VerificationController
    {
        public static async Task<User?> VerifyUserAsync(UserLoginRequest request, IUserService userService)
        {
            User? user = await userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }
        public static void CreatePasswordHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //True if password verified
        public static bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
