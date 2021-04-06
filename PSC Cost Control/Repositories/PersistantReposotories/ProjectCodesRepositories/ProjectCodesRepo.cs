using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.SPs;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using PSC_Cost_Control.Trackers.PersistantCruds;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesRepo : HireachyRepo<C_Cost_Project_Codes>, IPersistent<C_Cost_Project_Codes>
    {
        public ProjectCodesRepo(ApplicationContext context) : base(context)
        {

        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Project_Codes;

        public int NextId { get => Context.C_Cost_Project_Codes.Max(c => c.Id) + 1; set => NextId = value; }

        public async Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnifiedAsync(int projectId)
        {
            return await Context.C_Cost_Project_Codes.Where(c => c.Project_Id == projectId).ToListAsync();
        }

        public async Task AddProjectCodes(List<ProjectCodeUdT> codes)
        {

            var proc = new ProjectCodesInserionSP()
            {
                list = codes
            };


            await Context.Database.ExecuteStoredProcedureAsync<ProjectCodesInserionSP>(proc);
        }

        public async Task UpdateProjectCodes(List<ProjectCodeUdT> codes, int projectId)
        {
           // Context.Clear_Project_Codes(projectId);
            await AddProjectCodes(codes);
        }

        public void UpdateNodeData(int codeId, ProjectCodeUdT code)
        {
            Context.f_COST_Update_Project_Code(codeId, code.Description, code.UnifiedCodeId, code.CategoryId, code.Code, code.parent);
        }

        public async Task AddCollection(IEnumerable<C_Cost_Project_Codes> entities)
        {
            await AddProjectCodes(
                entities.Select(e => new ProjectCodeUdT
                {
                    Id = NextId,
                    CategoryId = e.Category_Id.Value,
                    Code = e.Code,
                    Description = e.Description,
                    parent = e.Parent.Value,
                    ProjectId = e.Project_Id.Value,
                    UnifiedCodeId = e.Unified_Code_Id.Value
                })
                .ToList());
        }

        public void UpdateCollction(IEnumerable<C_Cost_Project_Codes> entities)
        {
            foreach (var e in entities)
                Context.f_COST_Update_Project_Code(e.Id, e.Description, e.Unified_Code_Id, e.Category_Id, e.Code, e.Parent);
        }

        public void DeleteCollection(IEnumerable<C_Cost_Project_Codes> entities)
        {
          /**  foreach (var e in entities)
                Context.Delete_parent_With_HisChilds(this.Table.ToString(), e.Id);
          **/
        }
    }
}
