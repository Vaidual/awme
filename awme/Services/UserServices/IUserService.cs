using Microsoft.AspNetCore.Mvc;
using awme.Data.Models;

namespace awme.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
    }
}
