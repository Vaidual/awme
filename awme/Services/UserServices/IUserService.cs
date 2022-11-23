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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Returns true if user exists and false overwise</returns>
        Task<bool> CheckIfUserExistsByEmail(string email);
        Task<User?> GetUserByEmail(string email);
        Task UpdateUser(User user, JsonPatchDocument<User> userUpdates);
        Task DeleteUser(int id);
    }
}
