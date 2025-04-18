using System.Collections.Generic;
using System.Threading.Tasks;
using BidModel = Tender_management.Models.Bid;

namespace TenderManagementSystem.Services.Bid
{
    public interface IBidService
    {
        Task<IEnumerable<BidModel>> GetAllBidsAsync();
        Task<BidModel> GetBidByIdAsync(int id);
        Task CreateBidAsync(BidModel bid);
        Task UpdateBidAsync(BidModel bid);
        Task DeleteBidAsync(int id);
        Task SubmitBidAsync(BidModel bid);
    }
}
