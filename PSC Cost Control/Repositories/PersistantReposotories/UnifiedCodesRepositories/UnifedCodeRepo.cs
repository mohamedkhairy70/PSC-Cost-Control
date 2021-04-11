using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.SPs;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using PSC_Cost_Control.Trackers.PersistantCruds;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public class UnifedCodeRepo : BaseRepo<C_Cost_Unified_Codes>, IAvailableId, IHirechicalPersistent<C_Cost_Unified_Codes>, IUnifedCodeRepo
    {
        protected override TablesEnum Table => TablesEnum.C_Cost_Unified_Codes;

        public UnifedCodeRepo(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodesAsync()
        {
            return await Context.C_Cost_Unified_Codes.ToListAsync();
        }

        public int NextId { get => Context.C_Cost_Project_Codes.Max(c => c.Id) + 1; set => NextId = value; }

        public async Task AddUnifiedCodesAsync(List<C_Cost_Unified_Codes> codes)
        {
            var proc = new UnifiedCodeInsertion()
            {
                list = codes.Select(c =>
                    new UnifiedCodeUDT
                    {
                        Id = c.Id,
                        CategoryId = c.Category_Id.Value,
                        Code = c.Code,
                        parent = c.Parent,
                        Title = c.Title
                    }
                ).ToList()
            };

            await Context.Database.ExecuteStoredProcedureAsync<UnifiedCodeUDT>(proc);
        }
        public void Update(C_Cost_Unified_Codes code)
        {
            Context.f_COST_Update_Unified_Code(code.Id, code.Title, code.Category_Id, code.Code, code.Parent);
        }

        public async Task AddCollection(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            await AddUnifiedCodesAsync(entities.ToList());
        }

        public void Delete(C_Cost_Unified_Codes unified)
        {
            Context.f_COST_Delete_By_Id(Table.ToString(), unified.Id);
        }
        public void UpdateCollction(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            foreach (var e in entities)
                Update(e);
        }

        public void DeleteCollection(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            entities.ToList()
                .ForEach(e => Delete(e));
        }

        public IDictionary<string, int> GetDamagedHiraichals(int? projectId)
        {
            using (var context = new Models.ApplicationContext())
            {
                return context.C_Cost_Project_Codes.Where(c => c.Parent == -1).Select(x => new { Code = x.Code, Id = x.Id })
                     .ToDictionary(c => c.Code, c => c.Id);
            }
        }
    }

}
