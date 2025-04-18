using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvaluationModel = Tender_management.Models.Evaluation;
using TenderManagementSystem.Services.Evaluation;

namespace Tender_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet]
        public async Task<IEnumerable<EvaluationModel>> GetAll()
        {
            return await _evaluationService.GetAllEvaluationsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationModel>> GetById(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null) return NotFound();
            return evaluation;
        }

        [HttpPost]
        public async Task<ActionResult> Create(EvaluationModel evaluation)
        {
            await _evaluationService.CreateEvaluationAsync(evaluation);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(EvaluationModel evaluation)
        {
            await _evaluationService.UpdateEvaluationAsync(evaluation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _evaluationService.DeleteEvaluationAsync(id);
            return Ok();
        }
    }
}
