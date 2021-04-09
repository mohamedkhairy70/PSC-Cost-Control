using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.PersistantCruds;
using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;

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
            var rt= await _projectCodesRepo.GetProjectCodesWithItsItsUnifiedAsync(projectId);
            return rt;
        }

        public async Task<IEnumerable<C_Cost_Project_Codes>> NewCodesForProject(int projectId, List<C_Cost_Project_Codes> codes)
        {

           (codes.InjectIds() as IEnumerable<IHireichy>).ReSolvingHireachicalParentChild();

            var lUDT = codes.Select(c => {
                return new ProjectCodeUdT
                {
                    Id=c.Id,
                    CategoryId = c.Category_Id.Value,
                    ProjectId = projectId,
                    Description = c.Description,
                    UnifiedCodeId = c.Unified_Code_Id.Value,
                    Code = c.Code,
                    parent =c.ParentId
                };
            }).ToList();
            await _projectCodesRepo.AddProjectCodes(lUDT);
            return await _projectCodesRepo.GetProjectCodesWithItsItsUnifiedAsync(projectId);
        }

        public async Task Update(int projectId, List<C_Cost_Project_Codes> codes)
        {
    
            var tracker = new Tracker<C_Cost_Project_Codes>((IPersistent<C_Cost_Project_Codes>)_projectCodesRepo,
                await _projectCodesRepo.GetProjectCodesWithItsItsUnifiedAsync(projectId));

            tracker.TrackCollection(codes);
            tracker.Commit();
        }




    }
}
