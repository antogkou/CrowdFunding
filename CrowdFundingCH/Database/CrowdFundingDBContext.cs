using CrowdFundingCH.Models;
using CrowdFundingMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrowdFundingCH.Areas.Identity.Data
{
    public class CrowdFundingDBContext : IdentityDbContext<ApplicationUser>
    {
        public CrowdFundingDBContext(DbContextOptions<CrowdFundingDBContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }

        public DbSet<BackedProjects> BackedProjects { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        //public DbSet<ProjectCategory> ProjectCategorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<BackedProjects>()
            //    .HasKey(lc => new { lc.FundId });
        }
    }
}

