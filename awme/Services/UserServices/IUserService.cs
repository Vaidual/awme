using Microsoft.AspNetCore.Mvc;
using awme.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace awme.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> AddUser(User user);
        Task<bool> CheckIfUserExistsByEmail(string email);
        Task<User?> GetUserByEmail(string email);
        Task UpdateUserFields(User user, JsonPatchDocument<User> userUpdates);
        Task DeleteUser(int id);
    }
}
