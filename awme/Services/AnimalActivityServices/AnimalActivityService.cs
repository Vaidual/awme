using AutoMapper;
using awme.Data.Dto.AnimalActivity;
using awme.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace awme.Services.AnimalActivityServices
{
    public class AnimalActivityService : IAnimalActivityService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimalActivityService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Activity> AddActivity(AnimalActivityAddRequest activityAddRequest)
        {
            Activity activity = new();
            _mapper.Map(activityAddRequest, activity);
            var result = await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteActivity(string collarId, DateOnly start, DateOnly end)
        {
            for (; start <= end; start = start.AddDays(1))
            {
                DateTime date = start.ToDateTime(TimeOnly.MinValue);
                List<Activity> activities = await _context.Activities.Where(a => a.CollarId == collarId && a.Time.Date == date).ToListAsync();
                _context.Activities.RemoveRange(activities);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<List<Activity>> GetActivity(string collarId)
        {
            return await _context.Activities.Where(a => a.CollarId == collarId).ToListAsync();
        }
    }
}
