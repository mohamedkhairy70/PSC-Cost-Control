using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;


namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    public class DirectItemRegisterationRepo : RegisterItem<C_Cost_Project_Codes_Items>
    {
        private  const string TYPE = "direct";
        public DirectItemRegisterationRepo(PSC_COST3Entities context) : base(context,TYPE)
        {
        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Project_Codes_Items;

    }
}
