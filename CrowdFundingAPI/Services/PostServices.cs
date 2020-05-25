using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Security.Claims;

namespace CrowdFundingAPI.Services
{
    public class PostServices : IPostServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProjectServices projectServices;

        public PostServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, IProjectServices _projectServices)
        {
            _db = db;
            httpContextAccessor = _httpContextAccessor;
            projectServices = _projectServices;
        }

        //Create post
        public Post CreatePost(PostOptions postOptions)
        {

            //ProjectPosts = new List<Post>
            //    {
            //        new Post { }
            //    };
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = projectServices.FindProjectById(postOptions.ProjectId);
            Post post = new Post
            {
                UserId = userId,
                Project = project,
                PostTitle = postOptions.PostTitle,
                PostDescription = postOptions.PostDescription
            };

            _db.Add(post);
            _db.SaveChanges();
            return post;
        }
    }
}