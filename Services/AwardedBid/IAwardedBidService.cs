using System.Collections.Generic;
using System.Threading.Tasks;
using AwardedBidModel = Tender_management.Models.AwardedBid;

namespace TenderManagementSystem.Services.AwardedBid
{
    public interface IAwardedBidService
    {
        Task<IEnumerable<AwardedBidModel>> GetAllAwardedBidsAsync();
        Task<AwardedBidModel> GetAwardedBidByIdAsync(int id);
        Task CreateAwardedBidAsync(AwardedBidModel awardedBid);
        Task UpdateAwardedBidAsync(AwardedBidModel awardedBid);
        Task DeleteAwardedBidAsync(int id);
    }
}
