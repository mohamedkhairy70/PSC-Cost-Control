using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public interface IProjectCodesRepo
    {
        int NextId { get; set; }

        Task AddProjectCodes(List<ProjectCodeUdT> codes);
        Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnofoedAsync(int projectId);
        void UpdateNodeData(int codeId, ProjectCodeUdT code);
        Task UpdateProjectCodes(List<ProjectCodeUdT> codes, int projectId);
    }
}