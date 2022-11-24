using awme.Data.Dto.Animal;
using awme.Data.Dto.Profile;
using awme.Data.Models;

namespace awme.Mapping
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnimalUpdateRequest, Animal>();
            CreateMap<ProfileUpdateRequest, Profile>();
            CreateMap<ProfileAddRequest, Profile>();
        }
    }
}
