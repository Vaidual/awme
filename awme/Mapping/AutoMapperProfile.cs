﻿using awme.Data.Dto.Animal;
using awme.Data.Dto.AnimalActivity;
using awme.Data.Dto.Collar;
using awme.Data.Dto.Post;
using awme.Data.Dto.Profile;
using awme.Data.Dto.User;
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
            CreateMap<User, UserGetRequest>();
            CreateMap<Collar, CollarGetRequest>();
            CreateMap<Profile, ProfilesGetRequest>()
                .ForMember(
                dest => dest.Followers, 
                opt => opt.MapFrom(src => src.Followers.Count))
                .ForMember(
                dest => dest.Following,
                opt => opt.MapFrom(src => src.Following.Count));
            CreateMap<ProfileBanPatchRequest, Profile>();
        }
    }
}
