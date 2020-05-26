using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IPostServices
    {
        Post CreatePost(PostOptions postOptions);
        bool DeletePost(int postId);
        List<Post> GetAllPosts(int projectId);
    }
}