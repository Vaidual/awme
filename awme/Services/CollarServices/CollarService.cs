using AutoMapper;
using awme.Data.Dto.Collar;
using awme.Data.Dto.User;
using awme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace awme.Services.CollarServices
{
    public class CollarService : ICollarService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CollarService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Collar> AddCollar(string deviceId)
        {
            var result = await _context.Collars.AddAsync(new Collar { Id = deviceId });
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> CheckIfCollarExists(string deviceId)
        {
            return await _context.Collars.AnyAsync(el => el.Id == deviceId);
        }

        public async Task<bool> DeleteCollar(string id)
        {
            var result = await GetCollar(id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Collar?> GetCollar(string id)
        {
            return await _context.Collars.Include(c => c.Animal).FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<List<CollarGetRequest>> GetCollars()
        {
            var result = _mapper.Map(await _context.Collars.Include(c => c.Animal).Include(c => c.User).ToListAsync(), new List<CollarGetRequest>());
            return result;
        }
    }
}
