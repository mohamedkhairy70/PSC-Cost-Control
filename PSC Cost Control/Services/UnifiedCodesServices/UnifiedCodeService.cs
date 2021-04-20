using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.Commiters;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.UnifiedCodesServices
{
    public class UnifiedCodeService : IUnifiedCodeService
    {
        private IUnifedCodeRepo _unifiedCodesRepo;
        private ITracker<C_Cost_Unified_Codes> _tracker;
        private UpdatingCommiter<C_Cost_Unified_Codes> _committer;
        public UnifiedCodeService(IUnifedCodeRepo codesRepo, ITracker<C_Cost_Unified_Codes> tracker)
        {
            _unifiedCodesRepo = codesRepo;
            _tracker = tracker;
            _committer = new HireaichalUpdatingCommitter< C_Cost_Unified_Codes >
                ((IPersistent <C_Cost_Unified_Codes>)_unifiedCodesRepo, _tracker);
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodes()
        {
            return await _unifiedCodesRepo.GetUnifiedCodesAsync();
        }

        public async Task NewUnifiedCodes(List<C_Cost_Unified_Codes> codes)
        {
            (codes.InjectFakeIds() as IEnumerable<IHireichy>).ReSolvingHireachicalParentChild();

            await _unifiedCodesRepo.AddUnifiedCodesAsync(codes);
        }

        public async Task Update(List<C_Cost_Unified_Codes> codes)
        {
            _tracker.SetOrigin(await _unifiedCodesRepo.GetUnifiedCodesAsync());
            _tracker.TrackCollection(codes);
            _committer.Commit();
        }
    }
}
