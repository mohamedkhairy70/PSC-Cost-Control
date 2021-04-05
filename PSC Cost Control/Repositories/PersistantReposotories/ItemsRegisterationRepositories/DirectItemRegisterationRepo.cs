using PSC_Cost_Control.Factories.PersistantCruds;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    public class DirectItemRegisterationRepo : RegisterItem<C_Cost_Project_Codes_Items,BOQ_Items>,IPersistent<C_Cost_Project_Codes_Items>
    {
        private  const string TYPE = "direct";
        public DirectItemRegisterationRepo(ApplicationContext context) : base(context,TYPE)
        {
        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Project_Codes_Items;

        public async Task AddCollection(IEnumerable<C_Cost_Project_Codes_Items> entities)
        {
            await Task.Run(() => AddCollectionHelper(entities));
        }
        private void AddCollectionHelper(IEnumerable<C_Cost_Project_Codes_Items> entities)
        {
            InsertItems(
                entities
                .Select(
                    e => new DirectItemProjectCode
                    {
                        Item = e.BOQ_Items,
                        ProjectCode = e.C_Cost_Project_Codes,
                        ItemId = e.Boq_Item_Id,
                        ProjecCodeId = e.Project_Code_Id
                    }
                    ));
        }

        public void DeleteCollection(IEnumerable<C_Cost_Project_Codes_Items> entities)
        {
            foreach (var e in entities)
                Context.f_COST_Delete_By_Id(Table.ToString(), e.Id);
        }

        public  override async Task<IEnumerable<C_Cost_Project_Codes_Items>> GetRegisterationsAsync(int projectId)
        {
            return await Context.C_Cost_Project_Codes_Items
                .Include(c => c.C_Cost_Project_Codes)
                .Where(c => c.C_Cost_Project_Codes.Project_Id == projectId)
                .ToListAsync();
        }

        public void UpdateCollction(IEnumerable<C_Cost_Project_Codes_Items> entities)
        {
            UpdateItems(
                entities
                .Select(e => new DirectItemProjectCodeWithId 
                {
                    Id=e.Id,
                    Item = e.BOQ_Items,
                    ProjectCode = e.C_Cost_Project_Codes,
                    ItemId = e.Boq_Item_Id,
                    ProjecCodeId = e.Project_Code_Id
                }));
        }
    }
}
