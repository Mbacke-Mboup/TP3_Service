using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlappyAPI.Modelss;
using Microsoft.AspNetCore.Identity;

namespace FlappyAPI.Data
{
    public class FlappyAPIContext : IdentityDbContext<User>
    {
        public FlappyAPIContext (DbContextOptions<FlappyAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            PasswordHasher<User> hasher = new PasswordHasher<User> ();
           
            User u1 = new User()
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "max",
            };
            u1.PasswordHash = hasher.HashPassword(u1, "12345");

            User u2 = new User()
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "bob",
                
            };
            u1.PasswordHash = hasher.HashPassword(u1, "12345");
            
            builder.Entity<User>().HasData(u1,u2);
            builder.Entity<Score>().HasData(
                new Score()
                {
                    Id = 1,
                    Date = DateTime.UtcNow.AddHours(1).ToString(),
                    ScoreValue = 54,
                    IsPublic = true,
                    TimeInSeconds = "54.99",
                    Pseudo = u1.UserName,
                    UserId = "11111111-1111-1111-1111-111111111111"
                },
                new Score()
                {
                    Id = 2,
                    Date = DateTime.UtcNow.AddHours(2).ToString(),
                    ScoreValue = 68,
                    IsPublic = false,
                    TimeInSeconds = "64.99",
                    Pseudo = u1.UserName,
                    UserId = "11111111-1111-1111-1111-111111111111"
                },
                 new Score()
                 {
                     Id = 3,
                     Date = DateTime.UtcNow.AddHours(1).ToString(),
                     ScoreValue = 54,
                     IsPublic = true,
                     TimeInSeconds = "54.99",
                     Pseudo = u2.UserName,
                     UserId = "11111111-1111-1111-1111-111111111112"
                 },
                new Score()
                {
                    Id = 4,
                    Date = DateTime.UtcNow.AddHours(2).ToString(),
                    ScoreValue = 68,
                    IsPublic = false,
                    TimeInSeconds = "64.99",
                    Pseudo = u2.UserName,
                    UserId = "11111111-1111-1111-1111-111111111112"
                }

                );
        }

        public DbSet<Score> Score { get; set; } = default!;
    }
}
