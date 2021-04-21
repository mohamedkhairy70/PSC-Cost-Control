using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.DTO;
using PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.Commiters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices
{
    public partial class ItemsRegisterationService : IRegisterationService
    {
        private readonly DirectItemRegisterationRepo _directRepo;
        private readonly IndirectCostItemRegisterationRepo _indirectRepo;
        private readonly ITracker<C_Cost_Project_Codes_Items> _directTracker;
        private readonly ITracker<C_Cost_Indirect_Project_Code_Summerizing> _inDirectTracker;
        private readonly IUpdatingCommiter _directComitter;
        private readonly IUpdatingCommiter _InDirectComitter;


        public ItemsRegisterationService
            (DirectItemRegisterationRepo directRepo
            , IndirectCostItemRegisterationRepo indirectRepo
            , ITracker<C_Cost_Project_Codes_Items> directTracker
            , ITracker<C_Cost_Indirect_Project_Code_Summerizing> inDirectTracker)
        {
            _directRepo = directRepo;
            _indirectRepo = indirectRepo;
            _directTracker = directTracker;
            _inDirectTracker = inDirectTracker;
            _directComitter = new NonHireaichalUpdatingCommitter<C_Cost_Project_Codes_Items>(_directRepo, _directTracker);
            _InDirectComitter = new NonHireaichalUpdatingCommitter<C_Cost_Indirect_Project_Code_Summerizing>(_indirectRepo, _inDirectTracker);
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
                        ItemId = i.BOQ_Items.Id,
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

        public void UpdateBOQItems(int projectId, IEnumerable<C_Cost_Project_Codes_Items> itemsCodes)
        {
            _directTracker.SetOrigin(_directRepo.GetRegisterationsAsync(projectId).Result);
            _directTracker.TrackCollection(itemsCodes);
            _directComitter.Commit();
        }

        public void UpdateInDirectItems(int projecId, IEnumerable<C_Cost_Indirect_Project_Code_Summerizing> itemsCodes)
        {
            _inDirectTracker.SetOrigin(_indirectRepo.GetRegisterationsAsync(projecId).Result);
            _inDirectTracker.TrackCollection(itemsCodes);
            _InDirectComitter.Commit();
        }
    }
}
