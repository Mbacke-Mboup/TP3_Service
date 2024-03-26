using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlappyAPI.Modelss;

namespace FlappyAPI.Data
{
    public class FlappyAPIContext : IdentityDbContext<User>
    {
        public FlappyAPIContext (DbContextOptions<FlappyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FlappyAPI.Models.Score> Score { get; set; } = default!;
    }
}
