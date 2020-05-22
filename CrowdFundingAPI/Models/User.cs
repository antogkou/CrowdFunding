using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Models
{
    public class User
    {
        public int user_Id { get; set; }

        public string user_First_Name { get; set; }

        public string user_Last_Name { get; set; }

        public string user_Email { get; set; }

        public string user_Phone { get; set; }

        public string user_VAT { get; set; }

        public ICollection<Project> UserCreatedProjects { get; set; }

        public DateTimeOffset UserDateCreated { get; set; }

        public User()
        {
            UserCreatedProjects = new List<Project>();
            UserDateCreated = DateTimeOffset.Now;
        }
    }
}
