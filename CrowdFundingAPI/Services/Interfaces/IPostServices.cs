using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IPostServices
    {
        Post CreatePost(PostOptions postOptions);
    }
}