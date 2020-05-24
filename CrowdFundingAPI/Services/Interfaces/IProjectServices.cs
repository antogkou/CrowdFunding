﻿using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IProjectServices
    {
        Project CreateProject(ProjectOptions projectoption);
        Project CreateProject2(ProjectOptions projectoption);
        IQueryable<Project> ListProjects(ProjectOptions options);
        IQueryable<Project> SearchProject2(ProjectOptions options);

        Project FindProjectById(int id);
        List<Project> SearchProject();

    }
}