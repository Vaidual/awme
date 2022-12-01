using AutoMapper;
using awme.Data.Dto.Animal;
using awme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace awme.Services.AnimalServices
{
    public class AnimalService : IAnimalService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimalService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            var result = await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            Animal? animal = await GetAnimal(id);
            if (animal == null)
            {
                return false;
            }
            _context.Remove(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Animal?> GetAnimal(int id)
        {
            return await _context.Animals.FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<List<Animal>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<List<Animal>> GetUserAnimals(int userId)
        {
            return await _context.Animals.Where(el => el.UserId == userId).ToListAsync();
        }

        public async Task<Animal> PatchCollar(Animal animal, Collar? collar)
        {
            if (collar == null) animal.CollarId = null;
            animal.Collar = collar;
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> UpdateAnimal(Animal animal, AnimalUpdateRequest update)
        {
            _mapper.Map(update, animal);
            await _context.SaveChangesAsync();
            return animal;
        }
    }
}
