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
    public class ProjectCodesRepo : BaseRepo<C_Cost_Project_Codes>, IProjectCodesRepo
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

       // public async Task<C_Cost_Project_Codes>UpdateHireachy
    }
}
