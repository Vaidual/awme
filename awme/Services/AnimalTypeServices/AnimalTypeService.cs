using AutoMapper;
using awme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace awme.Services.AnimalTypeServices
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimalTypeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AnimalType> AddType(string type)
        {
            var result = await _context.AnimalTypes.AddAsync(new AnimalType { TypeName = type});
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> CheckIfTypeExists(string type)
        {
            return await _context.AnimalTypes.AnyAsync(el => el.TypeName == type);
        }

        public async Task<bool> DeleteType(int id)
        {
            var result = await GetType(id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<AnimalType?> GetType(int id)
        {
            return await _context.AnimalTypes.FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<List<AnimalType>> GetTypes()
        {
            return await _context.AnimalTypes.ToListAsync();
        }
    }
}
