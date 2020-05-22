using CrowdFundingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Database
{
    public class CrFrDbContext : DbContext
    {
        public readonly string connectionString_;

        public CrFrDbContext()
        {
            connectionString_ = "Server=localhost;Database=crowdfundingDB;User id=sa;Password=admin!@#123";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create User table
            modelBuilder
                .Entity<User>()
                .ToTable("User");

            modelBuilder
                .Entity<User>()
                .Property(u => u.user_First_Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.user_Last_Name)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .Property(u => u.user_Email)
                .IsRequired()
                .HasMaxLength(255);

            // Create Project table
            modelBuilder
                .Entity<Project>()
                .ToTable("Project");

            modelBuilder
                .Entity<Project>()
                .Property(p => p.ProjectTitle)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder
                .Entity<Project>()
                .Property(p => p.ProjectTargetAmount)
                .IsRequired()
                .HasMaxLength(20);

            // Create Media table
            modelBuilder
                .Entity<Multimedia>()
                .ToTable("Multimedia");

            modelBuilder
                .Entity<Multimedia>()
                .Property(m => m.MultimediaURL)
                .IsRequired();

            // Create Pledge table
            modelBuilder
                .Entity<Pledge>()
                .ToTable("Pledge");

            modelBuilder
                .Entity<Pledge>()
                .Property(p => p.PledgeTitle)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder
                .Entity<Pledge>()
                .Property(i => i.PledgePrice)
                .IsRequired()
                .HasMaxLength(20);

            // Create BackedPledges - connects user id and peldge id
            modelBuilder
                .Entity<BackedPledges>()
                .ToTable("BackedPledges");

            modelBuilder
                .Entity<BackedPledges>()
                .HasKey(key => new { key.UserId, key.PledgeId });

           
            // Post table
            modelBuilder
                .Entity<Post>()
                .ToTable("Post");

            modelBuilder
                .Entity<Post>()
                .Property(p => p.PostTitle)
                .IsRequired()
                .HasMaxLength(255);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString_);
        }
    }
}

