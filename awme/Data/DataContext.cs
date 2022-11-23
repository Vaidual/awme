using awme.Controllers;
using awme.Data.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace awme.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string password = "string";
            HashController.CreatePasswordHash(
                password,
                out byte[] passwordHash,
                out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                { 
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = "Admin"
                });

            modelBuilder.Entity<Chat>().HasOne(c => c.FirstProfile).WithOne()
            .HasForeignKey<Chat>(a => a.FirstProfileId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>().HasOne(a => a.SecondProfile).WithOne()
                  .HasForeignKey<Chat>(a => a.SecondProfileId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>().HasOne(a => a.Profile).WithOne()
                .HasForeignKey<Comment>(a => a.ProfileId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Like>().HasOne(a => a.Profile).WithOne()
                .HasForeignKey<Like>(a => a.ProfileId).OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
