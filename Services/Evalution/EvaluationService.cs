using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender_management.Infrastructure;
using EvaluationModel = Tender_management.Models.Evaluation;

namespace TenderManagementSystem.Services.Evaluation
{
    public class EvaluationService : IEvaluationService
    {
        private readonly EFCoreDBContext _context;

        public EvaluationService(EFCoreDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EvaluationModel>> GetAllEvaluationsAsync()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public async Task<EvaluationModel> GetEvaluationByIdAsync(int id)
        {
            return await _context.Evaluations.FindAsync(id);
        }

        public async Task CreateEvaluationAsync(EvaluationModel evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvaluationAsync(EvaluationModel evaluation)
        {
            _context.Evaluations.Update(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvaluationAsync(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
