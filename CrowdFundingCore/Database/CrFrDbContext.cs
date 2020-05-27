using CrowdFundingCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrowdFundingCore.Database
{
    public class CrFrDbContext : IdentityDbContext<MyUsers>
    {


        public readonly static string connectionString =
            "Server=localhost;Database=identityDB;User id=sa;Password=admin!@#123;MultipleActiveResultSets=true";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyUsers>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);
                b.Property(p => p.Id).HasColumnName("UserId");
                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                // Maps to the AspNetUsers table
                b.ToTable("MyUsers");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256).IsRequired();
                b.Property(u => u.NormalizedEmail).HasMaxLength(256).IsRequired();

                //b.Property(u => u.user_First_Name).HasMaxLength(256).IsRequired();
                //b.Property(u => u.user_Last_Name).HasMaxLength(256).IsRequired();

                // The relationships between User and other entity types
                // Note that these relationships are configured with no navigation properties


            });


            // Create User table
            //modelBuilder
            //    .Entity<User>()
            //    .ToTable("User");

            //modelBuilder
            //    .Entity<User>()
            //    .Property(u => u.user_First_Name)
            //    .IsRequired()
            //    .HasMaxLength(255);

            //modelBuilder
            //    .Entity<User>()
            //    .HasIndex(u => u.user_Last_Name)
            //    .IsUnique();

            //modelBuilder
            //    .Entity<User>()
            //    .Property(u => u.user_Email)
            //    .IsRequired()
            //    .HasMaxLength(255);

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

            //modelBuilder
            //    .Entity<BackedPledges>()
            //    .HasKey(key => new { key.UserId, key.PledgeId });


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
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}