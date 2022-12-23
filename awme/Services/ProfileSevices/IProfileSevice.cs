using awme.Data.Dto.Animal;
using awme.Data.Dto.Profile;
using awme.Data.Models;

namespace awme.Services.ProfileSevices
{
    public interface IProfileSevice
    {
        Task<List<ProfilesGetRequest>> GetProfiles();
        Task<Profile?> GetProfile(int id);
        Task<Profile> AddProfile(ProfileAddRequest request, User user);
        Task<bool> DeleteProfile(int id);
        Task<Profile> UpdateProfile(Profile profile, ProfileUpdateRequest update);
        Task<Profile> UpdateProfileBan(Profile profile, ProfileBanPatchRequest patch);
        Task<bool> CheckIfUsernameIsTaken(string username);
    }
}
