using System.Collections.Generic;

namespace CrowdFundingMVC.Models.Admin
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
