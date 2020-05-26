using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CrowdFundingCore.Models
{
    // Add profile data for application users by adding properties to the MyUsers class
    public class MyUsers : IdentityUser
    {
        //public MyUsers MyUser { get; set; }

        //public string user_First_Name { get; set; } = null!;

        //public string user_Last_Name { get; set; } = null!;

        //public string user_VAT { get; set; } = null!;
        
        public ICollection<Project> UserCreatedProjects { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public DateTimeOffset UserDateCreated { get; set; } 

        public MyUsers()
        {
            UserCreatedProjects = new List<Project>();
            UserDateCreated = DateTimeOffset.Now;
           // this.Id = Guid.NewGuid().ToString();
        }
       
    }

}
