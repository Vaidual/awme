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
        Task<bool> CheckIfUserExistsById(int id);
        Task<User?> GetUserByEmail(string email);
        Task UpdateUserFields(User user, JsonPatchDocument<User> userUpdates);
        Task UpdateUserRole(User user, Role role);
        Task<bool> DeleteUser(int id);
    }
}
