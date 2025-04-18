using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwardedBidModel = Tender_management.Models.AwardedBid;
using TenderManagementSystem.Services.AwardedBid;

namespace Tender_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwardedBidController : ControllerBase
    {
        private readonly IAwardedBidService _awardedBidService;

        public AwardedBidController(IAwardedBidService awardedBidService)
        {
            _awardedBidService = awardedBidService;
        }

        [HttpGet]
        public async Task<IEnumerable<AwardedBidModel>> GetAll()
        {
            return await _awardedBidService.GetAllAwardedBidsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AwardedBidModel>> GetById(int id)
        {
            var awardedBid = await _awardedBidService.GetAwardedBidByIdAsync(id);
            if (awardedBid == null) return NotFound();
            return awardedBid;
        }

        [HttpPost]
        public async Task<ActionResult> Create(AwardedBidModel awardedBid)
        {
            await _awardedBidService.CreateAwardedBidAsync(awardedBid);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(AwardedBidModel awardedBid)
        {
            await _awardedBidService.UpdateAwardedBidAsync(awardedBid);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _awardedBidService.DeleteAwardedBidAsync(id);
            return Ok();
        }
    }
}
