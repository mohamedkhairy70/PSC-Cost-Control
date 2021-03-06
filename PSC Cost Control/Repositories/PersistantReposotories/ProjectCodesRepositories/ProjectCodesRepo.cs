using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.SPs;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using PSC_Cost_Control.Trackers.PersistantCruds;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesRepo : HireachyRepo<C_Cost_Project_Codes>, IHirechicalPersistent<C_Cost_Project_Codes>, IProjectCodesRepo
    {
        public ProjectCodesRepo()
        {

        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Project_Codes;


        public async Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnifiedAsync(int projectId)
        {
            using (var Context = new ApplicationContext())
            {
                return  await Context.C_Cost_Project_Codes.Where(c => c.Project_Id == projectId).ToListAsync();
            }
        }

        public async Task AddProjectCodes(List<ProjectCodeUdT> codes)
        {
            using (var Context = new ApplicationContext())
            {
                var proc = new ProjectCodesInserionSP()
                {
                    list = codes
                };

                await Context.Database.ExecuteStoredProcedureAsync<ProjectCodesInserionSP>(proc);
            }
        }


        public async Task AddCollection(IEnumerable<C_Cost_Project_Codes> entities)
        {
            await AddProjectCodes(
                entities.Select(e => new ProjectCodeUdT
                {
                    Id = e.Id,
                    CategoryId = e.Category_Id.Value,
                    Code = e.Code,
                    Description = e.Description,
                    parent = null,//adding in persistent is without parent
                    ProjectId = e.Project_Id.Value,
                    UnifiedCodeId = e.Unified_Code_Id.Value
                })
                .ToList());
        }

        public void UpdateCollection(IEnumerable<C_Cost_Project_Codes> entities)
        {
            using (var Context = new ApplicationContext())
            {
                var proc = new UpdateProjectCodesSP
                {
                    list = entities.Select(x => new ProjectCodeUdT
                    {
                        Id = x.Id,
                        Code = x.Code,
                        CategoryId = x.Category_Id.Value,
                        Description = x.Description,
                        parent = x.Parent,
                        ProjectId = x.Project_Id.Value,
                        UnifiedCodeId = x.Unified_Code_Id.Value
                    }).ToList()
                };
                Context.Database.ExecuteStoredProcedure<UpdateProjectCodesSP>(proc);
            }
          
        }

        public void DeleteCollection(IEnumerable<C_Cost_Project_Codes> entities)
        {
            using (var Context = new ApplicationContext())
            {
                foreach (var e in entities)
                    Context.f_Cost_Delete_Parent_With_Childs(Table.ToString(), e.Id);
            }
        }

        public IDictionary<string, int> GetDamagedHiraichals(int? projectId)
        {
            using (var context = new ApplicationContext())
            {
               return context.C_Cost_Project_Codes.Where(c => c.Parent == null &&c.Project_Id==projectId)
                    .Select(x => new { Code = x.Code, Id = x.Id })
                    .ToDictionary(c => c.Code, c => c.Id);
            }
        }
    }
}
