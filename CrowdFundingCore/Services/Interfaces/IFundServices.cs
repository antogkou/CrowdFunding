using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IFundServices
    {
        Result<Fund> AddFund(FundOptions fundOptions);
    }
}
