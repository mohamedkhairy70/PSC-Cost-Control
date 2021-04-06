using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.PersistantCruds;

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
            return await _projectCodesRepo.GetProjectCodesWithItsItsUnofoedAsync(projectId);
        }

        public async Task<IEnumerable<C_Cost_Project_Codes>>NewCodesForProject(int projectId,List<C_Cost_Project_Codes> codes)
        {
            var nextId = _projectCodesRepo.NextId;
            var lUDT = codes.Select(c => new ProjectCodeUdT
            {
                Id =nextId++,
                CategoryId=c.Category_Id.Value,
                ProjectId=projectId,
                Description=c.Description,
                UnifiedCodeId=c.Unified_Code_Id.Value,
                Code=c.Code,
                parent=((C_Cost_Project_Codes)c.HParent).Id
            }).ToList();
            await _projectCodesRepo.AddProjectCodes(lUDT);
            return await _projectCodesRepo.GetProjectCodesWithItsItsUnofoedAsync(projectId);
        }

        public async Task Update(int projectId,List<C_Cost_Project_Codes> codes)
        {
            var tracker = new Tracker<C_Cost_Project_Codes>((IPersistent<C_Cost_Project_Codes>)_projectCodesRepo,
                await _projectCodesRepo.GetProjectCodesWithItsItsUnofoedAsync(projectId));
            tracker.TrackCollection(codes);
            tracker.Commit();
        }




    }
}
