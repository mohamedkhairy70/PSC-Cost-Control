using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Services.ProjectCodesServices
{
    public class ProjectCodeService : IProjectCodeService
    {
        private IProjectCodesRepo _projectCodesRepo;
        public ProjectCodeService(IProjectCodesRepo codesRepo)
        {
            _projectCodesRepo = codesRepo;
        }
        public async Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodes(int projectId)
        {
            return await _projectCodesRepo.GetProjectCodesAsync(projectId);
        }


    }
}
