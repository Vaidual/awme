using Microsoft.AspNetCore.Mvc;
using awme.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using awme.Data.Dto.User;
using SimplePatch;

namespace awme.Services.UserServices
{
    public interface IUserService
    {
        Task<User> AddCollar(User user, Collar collar);
        Task<List<UserGetRequest>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> AddUser(User user);
        Task<bool> CheckIfUserExistsByEmail(string email);
        Task<bool> CheckIfUserExistsById(int id);
        Task<bool> CheckIfUserHaveCollar(int userId, string collarId);
        Task<User?> GetUserByEmail(string email);
        Task<User> UpdateUserFields(User user, Delta<User> patch);
        Task UpdateUserRole(User user, Role role);
        Task<bool> DeleteUser(int id);
    }
}
