using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Post> ListPosts(PostOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _db
                .Set<Post>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.PostTitle))
            {
                query = query.Where(c => c.PostTitle == options.PostTitle);
            }

            if (!string.IsNullOrWhiteSpace(options.PostDescription))
            {
                query = query.Where(c => c.PostDescription == options.PostDescription);
            }
            query = query.Take(500);

            return query;
        }
    }
}