using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tender_management.Models;
using TenderManagementSystem.Services.Bid;

namespace Tender_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        // GET: api/Bid
        [HttpGet]
        public async Task<IActionResult> GetAllBids()
        {
            var bids = await _bidService.GetAllBidsAsync();
            return Ok(bids);
        }

        // GET: api/Bid/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidById(int id)
        {
            var bid = await _bidService.GetBidByIdAsync(id);
            if (bid == null)
                return NotFound();
            return Ok(bid);
        }

        // POST: api/Bid
        [HttpPost]
        public async Task<IActionResult> SubmitBid([FromBody] Bid bid)
        {
            await _bidService.SubmitBidAsync(bid);
            return CreatedAtAction(nameof(GetBidById), new { id = bid.BidId }, bid);
        }

        // PUT: api/Bid/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] Bid bid)
        {
            if (id != bid.BidId)
                return BadRequest("Bid ID mismatch");

            await _bidService.UpdateBidAsync(bid);
            return NoContent();
        }

        // DELETE: api/Bid/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            await _bidService.DeleteBidAsync(id);
            return NoContent();
        }
    }
}
