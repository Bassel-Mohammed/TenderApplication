using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tender_management.Infrastructure;
using Tender_management.Models;
using BidModel = Tender_management.Models.Bid;

namespace TenderManagementSystem.Services.Bid
{
    public class BidService : IBidService
    {
        private readonly EFCoreDBContext _context;
        private readonly DocumentGenerationService _documentService;

        public BidService(EFCoreDBContext context, DocumentGenerationService documentService)
        {
            _context = context;
            _documentService = documentService;
        }

        public async Task<IEnumerable<BidModel>> GetAllBidsAsync()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task<BidModel> GetBidByIdAsync(int id)
        {
            return await _context.Bids.FindAsync(id);
        }

        public async Task CreateBidAsync(BidModel bid)
        {
            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBidAsync(BidModel bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBidAsync(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SubmitBidAsync(BidModel bid)
        {
            bid.Status = "Submitted";  
            _context.Bids.Update(bid); 
            await _context.SaveChangesAsync();

          
            _documentService.GenerateBidDocument(bid);
        }
    }
}
