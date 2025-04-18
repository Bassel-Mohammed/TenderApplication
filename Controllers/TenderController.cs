using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tender_management.Models;
using TenderManagementSystem.Services.Tender;

namespace Tender_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        // GET: api/Tender
        [HttpGet]
        public async Task<IActionResult> GetAllTenders()
        {
            var tenders = await _tenderService.GetAllTendersAsync();
            return Ok(tenders);
        }

        // GET: api/Tender/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            var tender = await _tenderService.GetTenderByIdAsync(id);
            if (tender == null)
                return NotFound();
            return Ok(tender);
        }

        // POST: api/Tender
        [HttpPost]
        public async Task<IActionResult> CreateTender([FromBody] Tender tender)
        {
            await _tenderService.CreateTenderAsync(tender);
            return CreatedAtAction(nameof(GetTenderById), new { id = tender.TenderId }, tender);
        }

        // PUT: api/Tender/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTender(int id, [FromBody] Tender tender)
        {
            if (id != tender.TenderId)
                return BadRequest("Tender ID mismatch");

            await _tenderService.UpdateTenderAsync(tender);
            return NoContent();
        }

        // DELETE: api/Tender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            await _tenderService.DeleteTenderAsync(id);
            return NoContent();
        }
    }
}
