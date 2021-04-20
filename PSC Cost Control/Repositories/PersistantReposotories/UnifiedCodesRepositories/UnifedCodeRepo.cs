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
    public class UnifedCodeRepo : BaseRepo<C_Cost_Unified_Codes>, IHirechicalPersistent<C_Cost_Unified_Codes>, IUnifedCodeRepo
    {
        protected override TablesEnum Table => TablesEnum.C_Cost_Unified_Codes;

        public UnifedCodeRepo()
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodesAsync()
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.C_Cost_Unified_Codes.ToListAsync();
            }
        }


        public async Task AddUnifiedCodesAsync(List<C_Cost_Unified_Codes> codes)
        {
            using (var Context = new ApplicationContext())
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
        }
        public void Update(C_Cost_Unified_Codes code)
        {
            using (var Context = new ApplicationContext())
            {
                Context.f_COST_Update_Unified_Code(code.Id, code.Title, code.Category_Id, code.Code, code.Parent);
            }
        }

        public async Task AddCollection(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            await AddUnifiedCodesAsync(entities.ToList());
        }

        public void Delete(C_Cost_Unified_Codes unified)
        {
            using (var Context = new ApplicationContext())
            {
                Context.f_Cost_Delete_Parent_With_Childs(Table.ToString(), unified.Id);
            }
        }
        public void UpdateCollection(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            using (var context = new ApplicationContext())
            {
                var proc = new UpdateUnifiedCodeSP
                {
                    list = entities.Select(c => new UnifiedCodeUDT
                    {
                        Id = c.Id,
                        Code = c.Code,
                        CategoryId = c.Category_Id.Value,
                        parent = c.Parent,
                        Title = c.Title
                    }).ToList()
                };
                context.Database.ExecuteStoredProcedure(proc);
            }

        }

        public void DeleteCollection(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            entities.ToList()
                .ForEach(e => Delete(e));
        }

        public IDictionary<string, int> GetDamagedHiraichals(int? projectId)
        {
            using (var context = new ApplicationContext())
            {
                return context.C_Cost_Unified_Codes.Where(c => c.Parent == null).Select(x => new { x.Code, x.Id })
                     .ToDictionary(c => c.Code, c => c.Id);
            }
        }
    }

}
