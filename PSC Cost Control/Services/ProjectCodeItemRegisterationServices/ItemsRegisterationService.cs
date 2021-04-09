using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories;
using PSC_Cost_Control.Trackers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices
{
    public partial class ItemsRegisterationService : IRegisterationService
    {
        private DirectItemRegisterationRepo _directRepo;
        private IndirectCostItemRegisterationRepo _indirectRepo;

        public ItemsRegisterationService(DirectItemRegisterationRepo directRepo, IndirectCostItemRegisterationRepo indirectRepo)
        {
            _directRepo = directRepo;
            _indirectRepo = indirectRepo;
        }

        public async Task<IEnumerable<C_Cost_Project_Codes_Items>> GetBOQRegisteration(int projectId)
        {
            return await _directRepo.GetRegisterationsAsync(projectId);
        }

        public async Task<IEnumerable<C_Cost_Indirect_Project_Code_Summerizing>> GetIndirectItemRegisteration(int projectId)
        {
            return await _indirectRepo.GetRegisterationsAsync(projectId);
        }

        public void RegisterBOQItems(IEnumerable<C_Cost_Project_Codes_Items> itemsCodes)
        {
            _directRepo
                .InsertItems(
                itemsCodes
                .Select(
                    i => new DirectItemProjectCode
                    {
                        ItemId = i.BOQ_Items.BOQId,
                        ProjecCodeId = i.C_Cost_Project_Codes.Id
                    }));
        }

      
        public void RegisterInDirectItems(IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> itemsCodes)
        {
            _indirectRepo
                .InsertItems(itemsCodes
                .Select(
                    i => new InDirectItemProjectCode
                    {
                        ItemId = i.IndirectCostItems.Id,
                        ProjecCodeId = i.C_Cost_Project_Codes.Id
                    }));
        }

        public void UpdateBOQItems(int projectId,IEnumerable<C_Cost_Project_Codes_Items> itemsCodes)
        {
            var tracker = new Tracker<C_Cost_Project_Codes_Items>(
                _directRepo, _directRepo.GetRegisterationsAsync(projectId).Result);

            tracker.TrackCollection(itemsCodes);
            tracker.Commit();
        }

        public void UpdateInDirectItems(int projecId,IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> itemsCodes)
        {
            var tracker = new Tracker<C_Cost_Indirect_Project_Code_Summerizing>(
                            _indirectRepo, _indirectRepo.GetRegisterationsAsync(projecId).Result);

            tracker.TrackCollection(itemsCodes);
            tracker.Commit();
        }
    }
}
