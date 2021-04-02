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

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public class UnifedCodeRepo : BaseRepo<C_Cost_Unified_Codes>,IAvailableId,IPersistent<C_Cost_Unified_Codes>
    {
        protected override TablesEnum Table => TablesEnum._Cost_Unified_Codes;

        public UnifedCodeRepo(PSC_COST3Entities context) : base(context)
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodesAsync()
        {
            return await Context.C_Cost_Unified_Codes.ToListAsync();
        }

        public int NextId { get => Context.C_Cost_Project_Codes.Max(c => c.Id)+1; set => NextId = value; }

        public async Task AddUnifiedCodesAsync(List<C_Cost_Unified_Codes> codes)
        {

            var proc = new UnifiedCodeInsertion()
            {
                list = codes.Select(c =>
                    new UnifiedCodeUDT
                    {
                        Id=NextId,
                        CategoryId = c.Category_Id.Value,
                        Code = c.Code,
                        parent = c.Parent.Value,
                        Title = c.Title
                    }
                ).ToList()
            };

            await Context.Database.ExecuteStoredProcedureAsync<UnifiedCodeUDT>(proc);
        }

        public async Task Add(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            await AddUnifiedCodesAsync(entities.ToList());
        }

        public void Update(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<C_Cost_Unified_Codes> entities)
        {
            throw new NotImplementedException();
        }
    }

}
