using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Models;

namespace ATCScheduler.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ATCScheduler.Models.Appointment> Appointment { get; set; }

        public DbSet<ATCScheduler.Models.ATController> ATController { get; set; }

        public DbSet<ATCScheduler.Models.Position> Position { get; set; }

        public DbSet<ATCScheduler.Models.Shift> Shift { get; set; }

        public DbSet<ATCScheduler.Models.SkillLevel> SkillLevel { get; set; }

        public DbSet<ATCScheduler.Models.TimeOffRequest> TimeOffRequest { get; set; }

        public DbSet<ATCScheduler.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
