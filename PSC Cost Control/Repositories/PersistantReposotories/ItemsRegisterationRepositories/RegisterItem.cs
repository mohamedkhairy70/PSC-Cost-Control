using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Models.SPs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public abstract class RegisterItem<T,V> : BaseRepo<T>
    {
        protected RegisterItem(ApplicationContext context,string itemType ) : base(context)
        {
            ItemType = itemType;
        }
        protected string ItemType;

        public  abstract Task<IEnumerable<T>> GetRegisterationsAsync(int projectId);
        public void InsertItems(IEnumerable<IItemPair<V>> pairs)
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

        public void UpdateItems(IEnumerable<IItemPairWithId<V>> pairs) {
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
