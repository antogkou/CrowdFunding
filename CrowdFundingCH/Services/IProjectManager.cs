using CrowdFundingCH.Models;
using CrowdFundingCH.Options;
using System.Threading.Tasks;

namespace CrowdFundingCH.Services
{
    public interface IProjectManager
    {
        Project CreateProject(ProjectOptions projectoption);
        Project FindProjectById(int id);
        Project FindProjectByName(ProjectOptions projectoption);
        
    }
}
