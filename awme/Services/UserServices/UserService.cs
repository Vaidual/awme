﻿using AutoMapper;
using awme.Data.Models;
using awme.Migrations;
using Azure.Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using User = awme.Data.Models.User;

namespace awme.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> CheckIfUserExistsByEmail(string email)
        {
            var result = await _context.Users.AnyAsync(u => u.Email == email);
            return result;
        }

        public async Task<bool> CheckIfUserExistsById(int id)
        {
            var result = await _context.Users.AnyAsync(u => u.Id == id);
            return result;
        }

        public async Task<bool> CheckIfUserHaveCollar(int userId, string collarId)
        {
            var result = await _context.Users.Where(u => u.Id == userId).Include(u => u.Collars).FirstOrDefaultAsync();
            return result!.Collars.Any(c => c.Id == collarId);
        }

        public async Task<User> AddCollar(User user, Collar collar)
        {
            collar.User = user;
            collar.InUse = true;
            await _context.SaveChangesAsync();
            return await GetUser(user.Id);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await GetUser(id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User?> GetUser(int id)
        {
            var result = await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(el => el.Id == id);
            return result;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(el => el.Email == email);
            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task UpdateUserFields(User user, JsonPatchDocument<User> userUpdates)
        {
            userUpdates.ApplyTo(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserRole(User user, Role role)
        {
            user.Role = role;
            await _context.SaveChangesAsync();
        }
    }
}