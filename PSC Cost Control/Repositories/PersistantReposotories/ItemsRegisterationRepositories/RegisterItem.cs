using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Models.SPs;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    public abstract class RegisterItem<T> : BaseRepo<T>
    {
        protected RegisterItem(PSC_COST3Entities context,string itemType ) : base(context)
        {
            ItemType = itemType;
        }
        protected string ItemType;

        public void InsertItems(IEnumerable<IItemPair<T>> pairs)
        {
            var proc = new RegisterItemsToProjectCodeSP()
            {
                type = ItemType,
                list = pairs
                .Select(
                    i => new Models.UDTs.ItemPairCodeUDT 
                    { 
                        ItemId = i.ItemId,ProjectCodeId=i.ProjecCodeId
                    }
                    ).ToList()
            };

            Context.Database.ExecuteStoredProcedure(proc);
        }

        public void UpdateItems(IEnumerable<IItemPairWithId<T>> pairs) {
            var proc = new UpdateItemsRegisterationSP
            {
                type = ItemType,
                list = pairs
                .Select(
                    i => new Models.UDTs.UpdateItemsCodeRegisteration
                    {
                        Id=i.Id,
                        ItemId = i.ItemId,
                        ProjectCodeId = i.ProjecCodeId
                    }
                    ).ToList()
            };

            Context.Database.ExecuteStoredProcedure(proc);

        }
    }
}
