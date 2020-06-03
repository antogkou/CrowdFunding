using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IProjectServices
    {
        Result<Project> CreateProject(ProjectOptions projectoption);
        IQueryable<Project> ListProjects(ProjectOptions options);
        IQueryable<Project> SearchProject(ProjectOptions options);
        Project FindProjectById(int id);
        Result<Project> UpdateProject(UpdateProjectOptions options);
        Result<Project> GetProjectById(int id);
        Result<Project> FindProjectById2(int projectId);
        IQueryable<Project> GetAllProjects(string projectCategory, string searchString);
        IQueryable<Project> GetMyProjects();
        IQueryable<Project> GetTrendingProjects();
        IQueryable<Project> GetCompletedProjects();
        IQueryable<Project> GetMyBackedProjects();
        //Project FindProjectByIdz(int projectId);
    }
}