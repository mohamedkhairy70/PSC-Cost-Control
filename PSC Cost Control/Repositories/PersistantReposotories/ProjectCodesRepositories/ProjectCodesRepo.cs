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

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesRepo : HireachyRepo<C_Cost_Project_Codes>, IProjectCodesRepo
    {
        public ProjectCodesRepo(PSC_COST3Entities context) : base(context)
        {

        }

        protected override TablesEnum Table => TablesEnum._Cost_Project_Codes;

        public async Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesAsync(int projectId)
        {
            return await Context.C_Cost_Project_Codes.Where(c => c.Project_Id == projectId).ToListAsync();
        }

        public async Task AddProjectCodes(List<ProjectCodeUdT> codes)
        {
            var proc = new ProjectCodesInserion()
            {
                list = codes.Select(c =>
                    new ProjectCodeUdT
                    {
                        CategoryId = c.CategoryId,
                        Code = c.Code,
                        parent = c.parent,
                        Description = c.Description,
                        ProjectId=c.ProjectId,
                        UnifiedCodeId=c.UnifiedCodeId
                    }
               ).ToList()
            };

            await Context.Database.ExecuteStoredProcedureAsync<ProjectCodesInserion>(proc);
        }

        public async Task UpdateProjectCodes(List<ProjectCodeUdT> codes,int projectId)
        {
            Context.Clear_Project_Codes(projectId);
            await AddProjectCodes(codes);
        }

        public void UpdateNodeData(int codeId,ProjectCodeUdT code)
        {
            Context.f_COST_Update_Project_Code(codeId, code.Description, code.UnifiedCodeId, code.CategoryId);
        }

      
    }
}
