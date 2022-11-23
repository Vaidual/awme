using awme.Data.Models;
using awme.Migrations;
using Azure.Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using User = awme.Data.Models.User;

namespace awme.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> CheckIfUserExistsByEmail(string email)
        {
            var result = await _context.Users.AnyAsync(u => u.Email == email);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetUser(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            return result;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(el => el.Email == email);
            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task UpdateUser(User user, JsonPatchDocument<User> userUpdates)
        {
            userUpdates.ApplyTo(user);
            await _context.SaveChangesAsync();
        }
    }
}
