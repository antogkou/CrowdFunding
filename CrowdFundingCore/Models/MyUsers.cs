using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CrowdFundingCore.Models
{
    // Add profile data for application users by adding properties to the MyUsers class
    public class MyUsers : IdentityUser
    {
      //  public int MyUserCustomId { get; set; }

        [PersonalData]
        public string userFirstName { get; set; }
        [PersonalData]
        public string userLastName { get; set; }
        [PersonalData]
        public int user_VAT { get; set; }
        
        public ICollection<Project> UserCreatedProjects { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public DateTimeOffset UserDateCreated { get; set; } 

        public MyUsers()
        {
            UserCreatedProjects = new List<Project>();
            UserDateCreated = DateTimeOffset.Now;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}