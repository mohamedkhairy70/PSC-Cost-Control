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
using PSC_Cost_Control.Trackers.Commiters;

namespace PSC_Cost_Control.Services.ProjectCodesServices
{
    public class ProjectCodeService : IProjectCodeService
    {
        private readonly IProjectCodesRepo _projectCodesRepo;
        private readonly ITracker<C_Cost_Project_Codes> _tracker;
        private readonly UpdatingCommiter<C_Cost_Project_Codes> _commiter;

        public ProjectCodeService(IProjectCodesRepo codesRepo,ITracker<C_Cost_Project_Codes> tracker)
        {
            _projectCodesRepo = codesRepo;
            _tracker = new Tracker<C_Cost_Project_Codes>();
             _commiter = new HireaichalUpdatingCommitter<C_Cost_Project_Codes>
               ((IPersistent<C_Cost_Project_Codes>)_projectCodesRepo, tracker);
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
            //inject projectId for every element in the list
            codes.ForEach(c => c.Project_Id = projectId);

            _tracker.SetOrigin(await _projectCodesRepo.GetProjectCodesWithItsItsUnifiedAsync(projectId));
            _tracker.TrackCollection(codes);
            _commiter.Commit();
        }




    }
}
