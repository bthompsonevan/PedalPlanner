using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PedalPlanner.Models;

namespace PedalPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PedalPlanner.Models.Pedal> Pedal { get; set; }
        public DbSet<PedalPlanner.Models.Rig> Rig { get; set; }
    }
}
