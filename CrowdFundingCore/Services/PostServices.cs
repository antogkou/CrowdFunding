using System;
using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingCore.Services
{
   
    public class PostServices : IPostServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProjectServices projectServices;

        public PostServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, 
            IProjectServices _projectServices)
        {
            _db = db;
            httpContextAccessor = _httpContextAccessor;
            projectServices = _projectServices;
        }

        //Create post TODO
        public Result<Post> CreatePost(PostOptions postOptions)
        {
            if (postOptions == null)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(postOptions.PostTitle))
            {
                return Result<Post>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PostTitle");
            }

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

            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Post could not be updated");
            }

            return Result<Post>.CreateSuccessful(post);
         
        }

        public Result<Post> UpdatePost(PostOptions postOptions)
        {
            if (postOptions == null)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(postOptions.PostTitle))
            {
                return Result<Post>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PostTitle");
            }

            //string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var post = _db.Set<Post>().Find(postOptions.PostId);


            post.PostTitle = postOptions.PostTitle;
            post.PostDescription = postOptions.PostDescription;
        

            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Post>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Post could not be updated");
            }

            return Result<Post>.CreateSuccessful(post);
         
        }

        //TODO result(?) not working check if user=active user
        public bool DeletePost(int postId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Post post = _db.Set<Post>()
                .Where(p => p.UserId == userId)
                .Where(p => p.PostId == postId)
                .SingleOrDefault();

             if (post != null)
            {
                _db.Set<Post>().Remove(post);
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        //NOTTODO
        public IQueryable<Post> SearchPosts(
            PostOptions postOptions)
        {
            if (postOptions == null)
            {
                return null;
            }

            var query = _db
                .Set<Post>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(postOptions.PostTitle))
            {
                query = query.Where(c => c.PostTitle == postOptions.PostTitle);
            }

            if (!string.IsNullOrWhiteSpace(postOptions.PostDescription))
            {
                query = query.Where(c => c.PostDescription == postOptions.PostDescription);
            }

            query = query.Take(500);

            return query;
        }

        //Get All Posts for current Project (working)
        public List<Post> GetAllPosts(int projectId)
        {
            return _db.Set<Post>()
                .Where(p => p.Project.ProjectId == projectId)
                .ToList();
        }

        //not used
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

        //find_post
        public Post FindPostById(int projectId, int postId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _db.Set<Post>()
                .Where(p => p.Project.ProjectId == projectId)
                .Where(p => p.PostId == postId)
                .Where(p => p.Project.UserId == userId)
                .SingleOrDefault();

            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}