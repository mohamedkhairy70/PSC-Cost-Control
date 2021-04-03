using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Services.ProjectCodesServices
{
    public class ProjectCodeCategoryService : IProjectCodeCategoryService
    {
        private IProjectCodesCategoriesRepo _repo;
        public ProjectCodeCategoryService(IProjectCodesCategoriesRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<C_Cost_Project_Code_Categories>> GetCategories()
        {
            return await _repo.GetCategoriesAsync();
        }

        public void Add(string name)
        {
            _repo.AddProjectCodeCategory(new C_Cost_Project_Code_Categories { Name = name });
        }
    }
}
