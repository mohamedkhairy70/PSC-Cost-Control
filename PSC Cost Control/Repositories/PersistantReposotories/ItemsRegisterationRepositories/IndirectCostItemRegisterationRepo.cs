using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    public class IndirectCostItemRegisterationRepo:RegisterItem<C_Cost_Indirect_Project_Code_Summerizing,IndirectCostItems>, IPersistent<C_Cost_Indirect_Project_Code_Summerizing>
    {
        private const string TYPE = "indirect";
        public IndirectCostItemRegisterationRepo(ApplicationContext context) : base(context, TYPE)
        {
        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Indirect_Project_Code_Summerizing;

        public async Task AddCollection(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> entities)
        {
            await Task.Run(() => AddCollectionHelper(entities));
        }
        private void AddCollectionHelper(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> entities)
        {
            InsertItems(
                entities
                .Select(
                    e => new InDirectItemProjectCode
                    {
                        Item = e.IndirectCostItems,
                        ProjectCode = e.C_Cost_Project_Codes,
                        ItemId = e.IndirectCostItems.Id,
                        ProjecCodeId = e.C_Cost_Project_Codes.Id
                    }
                    ));
        }

        public void DeleteCollection(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> entities)
        {
            foreach (var e in entities)
                Context.f_COST_Delete_By_Id(Table.ToString(), e.Id);
        }


        public override async Task<IEnumerable<C_Cost_Indirect_Project_Code_Summerizing>> GetRegisterationsAsync(int projectId)
        { 
            var data= await Context.C_Cost_Indirect_Project_Code_Summerizing
                .Include(c => c.C_Cost_Project_Codes)
                .Where(z => z.C_Cost_Project_Codes.Project_Id == projectId)
                .ToListAsync();
            return data;
        }
        public void UpdateCollction(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> entities)
        {
            UpdateItems(
                entities
                .Select(
                    e => new IndirectItemProjecCodeWithId
                {
                    Id = e.Id,
                    Item = e.IndirectCostItems,
                    ProjectCode = e.C_Cost_Project_Codes,
                    ItemId = e.IndirectCostItems.Id,
                    ProjecCodeId = e.C_Cost_Project_Codes.Id
                }));
        }
    }
}
