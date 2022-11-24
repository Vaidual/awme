using awme.Data.Dto.Animal;
using awme.Data.Dto.Profile;
using awme.Data.Models;

namespace awme.Services.ProfileSevices
{
    public interface IProfileSevice
    {
        Task<List<Profile>> GetProfiles();
        Task<Profile?> GetProfile(int id);
        Task<Profile> AddProfile(ProfileAddRequest request, User user);
        Task<bool> DeleteProfile(int id);
        Task<Profile> UpdateProfile(Profile profile, ProfileUpdateRequest update);
        Task<bool> CheckIfUsernameIsTaken(string username);
    }
}
