using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public interface IProjectCodesCategoriesRepo
    {
        void AddProjectCodeCategory(C_Cost_Project_Code_Categories category);
        Task<IEnumerable<C_Cost_Project_Code_Categories>> GetCategoriesAsync();
    }
}