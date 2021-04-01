using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.ProjectCodesServices
{
    public interface IProjectCodeService
    {
        Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodes(int projectId);
    }
}