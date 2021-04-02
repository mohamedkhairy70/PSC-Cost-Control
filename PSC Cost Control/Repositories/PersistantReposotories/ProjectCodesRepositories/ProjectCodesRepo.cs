using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Factories.PersistantCruds;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.SPs;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.Helpers.Enums;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesRepo : HireachyRepo<C_Cost_Project_Codes>, IProjectCodesRepo,IPersistent<C_Cost_Project_Codes>
    {
        public ProjectCodesRepo(PSC_COST3Entities context) : base(context)
        {

        }

        protected override TablesEnum Table => TablesEnum._Cost_Project_Codes;

        public int NextId { get => Context.C_Cost_Project_Codes.Max(c => c.Id) + 1; set => NextId = value; }

        public async Task<IEnumerable<C_Cost_Project_Codes>> GetProjectCodesWithItsItsUnofoedAsync(int projectId)
        {
            return await Context.C_Cost_Project_Codes.Where(c => c.Project_Id == projectId).ToListAsync();
        }

        public async Task AddProjectCodes(List<ProjectCodeUdT> codes)
        {
          
            var proc = new ProjectCodesInserion()
            {
                list=codes
            };


            await Context.Database.ExecuteStoredProcedureAsync<ProjectCodesInserion>(proc);
        }

        public async Task UpdateProjectCodes(List<ProjectCodeUdT> codes, int projectId)
        {
            Context.Clear_Project_Codes(projectId);
            await AddProjectCodes(codes);
        }

        public void UpdateNodeData(int codeId, ProjectCodeUdT code)
        {
            Context.f_COST_Update_Project_Code(codeId, code.Description, code.UnifiedCodeId, code.CategoryId);
        }

        public async Task Add(IEnumerable<C_Cost_Project_Codes> entities)
        {
            var x = entities.Select(e => new ProjectCodeUdT
            {
                Id = e.Id,
                CategoryId = e.Category_Id.Value,
                Code = e.Code,
                Description = e.Description,
                parent = e.Parent.Value,
                ProjectId = e.Project_Id.Value,
                UnifiedCodeId = e.Unified_Code_Id.Value
            }).ToList();
            await AddProjectCodes(x);
        }

        public void Update(IEnumerable<C_Cost_Project_Codes> entities)
        {
           /** foreach(var e in entities)
                Context.f_COST_Update_Project_Code()**/
        }

        public void Delete(IEnumerable<C_Cost_Project_Codes> entities)
        {
            throw new NotImplementedException();
        }
    }
}
