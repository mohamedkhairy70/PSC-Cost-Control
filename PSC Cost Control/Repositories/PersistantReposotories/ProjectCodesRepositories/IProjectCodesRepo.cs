using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public interface IProjectCodesRepo
    {
        Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesAsync(int projectId);
    }
}