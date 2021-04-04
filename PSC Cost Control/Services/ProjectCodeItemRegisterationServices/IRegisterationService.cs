using PSC_Cost_Control.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices
{
    public interface IRegisterationService
    {
        void RegisterBOQItems(IEnumerable<DirectItemProjectCode> itemsCodes);
        void RegisterInDirectItems(IEnumerable<InDirectItemProjectCode> itemsCodes);
        void UpdateBOQItems(IEnumerable<DirectItemProjectCode> itemsCodes);
        void UpdateInDirectItems(IEnumerable<InDirectItemProjectCode> itemsCodes);
        IEnumerable<DirectItemProjectCode> GetBOQRegisteration(int projectId);
        IEnumerable<InDirectItemProjectCode> GetIndirectItemRegisteration(int projectId);
    }
}
