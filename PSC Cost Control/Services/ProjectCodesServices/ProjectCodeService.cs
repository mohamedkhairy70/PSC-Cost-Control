using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Services.ProjectCodesServices
{
    public class ProjectCodeService
    {
        private IProjectCodesRepo _projectCodesRepo;
        public ProjectCodeService(IProjectCodesRepo codesRepo)
        {
            _projectCodesRepo = codesRepo;
        }
       // public async Task<List<>>
    }
}
