using awme.Data.Dto.AnimalActivity;
using awme.Data.Models;

namespace awme.Services.AnimalActivityServices
{
    public interface IAnimalActivityService
    {
        Task<List<Activity>> GetActivity(string collarId);
        Task<Activity> AddActivity(AnimalActivityAddRequest activityAddRequest);
        Task DeleteActivity(string collarId, DateOnly start, DateOnly end);
    }
}
