using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public interface IProjectCodesRepo
    {
        int NextId { get; set; }

        Task Add(IEnumerable<C_Cost_Project_Codes> entities);
        Task AddProjectCodes(List<ProjectCodeUdT> codes);
        void Delete(IEnumerable<C_Cost_Project_Codes> entities);
        Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnofoedAsync(int projectId);
        void Update(IEnumerable<C_Cost_Project_Codes> entities);
        void UpdateNodeData(int codeId, ProjectCodeUdT code);
        Task UpdateProjectCodes(List<ProjectCodeUdT> codes, int projectId);
    }
}