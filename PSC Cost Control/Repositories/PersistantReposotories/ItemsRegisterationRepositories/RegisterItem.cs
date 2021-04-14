using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Models.SPs;
using System;
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
        protected RegisterItem(string itemType ) 
        {
            ItemType = itemType;
        }
        protected string ItemType;

        public  abstract Task<IEnumerable<T>> GetRegisterationsAsync(int projectId);
        /**
         * *
         * "Violation of PRIMARY KEY constraint 'PK_C_Cost_Direct_Project_Codes_Summerizng'. Cannot insert duplicate key in object 'dbo.C_Cost_Direct_Project_Codes_Summerizng'. 
         * The duplicate key value is (30, 1).\r\nThe statement has been terminated."
         */
        public void InsertItems(IEnumerable<IItemPair<V>> pairs)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    var proc = new RegisterItemsToProjectCodeSP()
                    {
                        type = ItemType,
                        list = pairs
                        .Select(
                            i => new Models.UDTs.ItemPairCodeUDT
                            {
                                ItemId = i.ItemId,
                                ProjectCodeId = i.ProjecCodeId
                            }
                            ).ToList()
                    };

                    context.Database.ExecuteStoredProcedure(proc);
                }
            } catch (Exception e) { throw e; }
        }
        

        public void UpdateItems(IEnumerable<IItemPairWithId<V>> pairs) {
            using (var context = new ApplicationContext())
            {

                var proc = new UpdateItemsRegisterationSP
                {
                    type = ItemType,
                    list = pairs
                .Select(
                    i => new Models.UDTs.UpdateItemsCodeRegisteration
                    {
                        Id = i.Id,
                        ItemId = i.ItemId,
                        ProjectCodeId = i.ProjecCodeId
                    }
                    ).ToList()

                };

                context.Database.ExecuteStoredProcedure(proc);
            }
        }

     
    }
}
