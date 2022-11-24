using awme.Data.Dto.Animal;
using awme.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace awme.Services.AnimalServices
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAnimals();
        Task<Animal?> GetAnimal(int id);
        Task<List<Animal>> GetUserAnimals(int userId);
        Task<Animal> AddAnimal(Animal animal);
        Task<bool> DeleteAnimal(int id);
        Task<Animal> UpdateAnimal(Animal animal, AnimalUpdateRequest update);
    }
}
