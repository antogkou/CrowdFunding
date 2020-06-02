using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IPostServices
    {
        bool DeletePost(int postId);
        List<Post> GetAllPosts(int projectId);
        Result<Post> CreatePost(PostOptions postOptions);
        Result<Post> EditPost(PostOptions postOptions);
    }
}