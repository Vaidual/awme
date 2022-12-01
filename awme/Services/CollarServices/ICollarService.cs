using awme.Data.Models;

namespace awme.Services.CollarServices
{
    public interface ICollarService
    {
        Task<List<Collar>> GetCollars();
        Task<Collar?> GetCollar(string id);
        Task<Collar> AddCollar(string deviceId);
        Task<bool> DeleteCollar(string id);
        Task<bool> CheckIfCollarExists(string deviceId);
    }
}
