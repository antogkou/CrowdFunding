using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Models
{
    public class ListUsersModel
    {
        public ListUsersModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        public List<string> Users { get; set; }
    }
}
