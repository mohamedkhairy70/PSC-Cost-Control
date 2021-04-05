using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories
{
    public class IndirectCostItemRegisterationRepo:RegisterItem<IndirectCostItems>
    {
        private const string TYPE = "indirect";
        public IndirectCostItemRegisterationRepo(PSC_COST3Entities context) : base(context, TYPE)
        {
        }

        protected override TablesEnum Table => TablesEnum.C_Cost_Indirect_Project_Code_Summerizing;
    }
}
