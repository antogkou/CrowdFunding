using CrowdFundingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.ViewModels
{
    public class AddPledgeVM
    {
        public Project Project { get; set; }
        public Pledge Pledge { get; set; }
    }
}
