using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender_management.Infrastructure;
using AwardedBidModel = Tender_management.Models.AwardedBid;

namespace TenderManagementSystem.Services.AwardedBid
{
    public class AwardedBidService : IAwardedBidService
    {
        private readonly EFCoreDBContext _context;

        public AwardedBidService(EFCoreDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AwardedBidModel>> GetAllAwardedBidsAsync()
        {
            return await _context.AwardedBids.ToListAsync();
        }

        public async Task<AwardedBidModel> GetAwardedBidByIdAsync(int id)
        {
            return await _context.AwardedBids.FindAsync(id);
        }

        public async Task CreateAwardedBidAsync(AwardedBidModel awardedBid)
        {
            await _context.AwardedBids.AddAsync(awardedBid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAwardedBidAsync(AwardedBidModel awardedBid)
        {
            _context.AwardedBids.Update(awardedBid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAwardedBidAsync(int id)
        {
            var awardedBid = await _context.AwardedBids.FindAsync(id);
            if (awardedBid != null)
            {
                _context.AwardedBids.Remove(awardedBid);
                await _context.SaveChangesAsync();
            }
        }
    }
}