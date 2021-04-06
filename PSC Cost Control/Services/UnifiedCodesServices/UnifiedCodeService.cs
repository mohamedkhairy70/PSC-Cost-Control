using PSC_Cost_Control.Models;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.UnifiedCodesServices
{
    public class UnifiedCodeService
    {
        private IUnifedCodeRepo _unifiedCodesRepo;
        public UnifiedCodeService(IUnifedCodeRepo codesRepo)
        {
            _unifiedCodesRepo = codesRepo;
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodes()
        {
            return await _unifiedCodesRepo.GetUnifiedCodesAsync();
        }

        public async Task NewUnifiedCodes(List<C_Cost_Unified_Codes> codes)
        {
             await _unifiedCodesRepo.AddUnifiedCodesAsync(codes);
        }

        public async Task Update(List<C_Cost_Unified_Codes> codes)
        {
            var tracker = new Tracker<C_Cost_Unified_Codes>((IPersistent<C_Cost_Unified_Codes>)_unifiedCodesRepo,
                await _unifiedCodesRepo.GetUnifiedCodesAsync());
            tracker.TrackCollection(codes);
            tracker.Commit();
        }
    }
}
