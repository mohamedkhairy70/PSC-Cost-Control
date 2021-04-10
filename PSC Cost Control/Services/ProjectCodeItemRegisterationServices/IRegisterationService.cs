using System.Collections.Generic;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
namespace PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices
{
    public interface IRegisterationService
    {
        void RegisterBOQItems(IEnumerable<C_Cost_Project_Codes_Items> itemsCodes);
        void RegisterInDirectItems(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> itemsCodes);
        void UpdateBOQItems(int projectId,IEnumerable<C_Cost_Project_Codes_Items> itemsCodes);
        void UpdateInDirectItems(int projectId,IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> itemsCodes);
        Task<IEnumerable<C_Cost_Project_Codes_Items>> GetBOQRegisteration(int projectId);
        Task<IEnumerable<C_Cost_Indirect_Project_Code_Summerizing>> GetIndirectItemRegisteration(int projectId);
    }
}
