using CrowdFundingCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CrowdFundingCore
{
    public class AdminConfiguration : IEntityTypeConfiguration<MyUsers>
    {
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<MyUsers> builder)
        {
            var admin = new MyUsers
            {
                Id = adminId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                //FirstName = "Master",
                //LastName = "Admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                //BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D"),
                //UserType = UserType.Administrator
            };
            admin.PasswordHash = PassGenerate(admin);
            builder.HasData(admin);
        }

        public string PassGenerate(MyUsers user)
        {
            var passHash = new PasswordHasher<MyUsers>();
            return passHash.HashPassword(user, "#Aa123456");
        }
    }
}
