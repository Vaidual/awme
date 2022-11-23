using awme.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace awme.Services.AnimalTypeService
{
    public interface IAnimalTypeService
    {
        Task<List<AnimalType>> GetTypes();
        Task<AnimalType?> GetType(int id);
        Task<AnimalType> AddType(string type);
        Task DeleteType(int id);
        Task<bool> CheckIfTypeExists(string type);
    }
}
