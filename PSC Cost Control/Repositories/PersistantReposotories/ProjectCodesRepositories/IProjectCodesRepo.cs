using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public interface IProjectCodesRepo
    {
        Task AddCollection(IEnumerable<C_Cost_Project_Codes> entities);
        Task AddProjectCodes(List<ProjectCodeUdT> codes);
        void DeleteCollection(IEnumerable<C_Cost_Project_Codes> entities);
        Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnifiedAsync(int projectId);
        void UpdateCollection(IEnumerable<C_Cost_Project_Codes> entities);
    }
}