using awme.Data.Dto.Animal;
using awme.Data.Dto.AnimalActivity;
using awme.Data.Dto.Post;
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
            CreateMap<AnimalActivityAddRequest, Activity>();
            CreateMap<PostAddRequest, Post>();
            CreateMap<PostUpdateRequest, Post>();
        }
    }
}
