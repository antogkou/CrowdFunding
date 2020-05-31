using CrowdFundingCore.Models;
using System.Collections.Generic;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IMultimediaServices
    {
        List<Multimedia> GetMultimediaOfProject(int projectId);
    }
}
