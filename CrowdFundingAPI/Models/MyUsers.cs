using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CrowdFundingAPI.Models
{
    // Add profile data for application users by adding properties to the MyUsers class
    public class MyUsers : IdentityUser
    {
        public int UserId { get; set; }

        public string user_First_Name { get; set; }

        public string user_Last_Name { get; set; }

        public string user_VAT { get; set; }

        public ICollection<Project> UserCreatedProjects { get; set; }

        public DateTimeOffset UserDateCreated { get; set; }

        public MyUsers()
        {
            UserCreatedProjects = new List<Project>();
            UserDateCreated = DateTimeOffset.Now;
        }
    }

}
