using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IPostServices
    {
        Post CreatePost(PostOptions postOptions);
        bool DeletePost(int postId);
        List<Post> GetAllPosts(int projectId);
    }
}