﻿using AutoMapper;
using awme.Data.Dto.Profile;
using awme.Data.Dto.User;
using awme.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Profile = awme.Data.Models.Profile;

namespace awme.Services.ProfileSevices
{
    public class ProfileSevice : IProfileSevice
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProfileSevice(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Profile> AddProfile(ProfileAddRequest request, User user)
        {
            var profile = _mapper.Map(request, new Profile { User = user });
            var result = await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns true if username is taken and false overwise</returns>
        public async Task<bool> CheckIfUsernameIsTaken(string username)
        {
            return await _context.Profiles.AnyAsync(p => p.Username == username);
        }

        public async Task<bool> DeleteProfile(int id)
        {
            Profile? result = await GetProfile(id);
            if (result == null)
            {
                return false;
            }
            _context.Profiles.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Profile?> GetProfile(int id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<List<ProfilesGetRequest>> GetProfiles()
        {
            var profiles = await _context.Profiles.Include(p => p.Followers).Include(p => p.Following).ToListAsync();
            var result = _mapper.Map(profiles, new List<ProfilesGetRequest>());
            return result;
        }

        public async Task<Profile> UpdateProfile(Profile profile, ProfileUpdateRequest update)
        {
            _mapper.Map(update, profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile> UpdateProfileBan(Profile profile, ProfileBanPatchRequest patch)
        {
            _mapper.Map(patch, profile);
            await _context.SaveChangesAsync();
            return profile;
        }
    }
}
