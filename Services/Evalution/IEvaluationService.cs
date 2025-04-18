using System.Collections.Generic;
using System.Threading.Tasks;
using EvaluationModel = Tender_management.Models.Evaluation;

namespace TenderManagementSystem.Services.Evaluation
{
    public interface IEvaluationService
    {
        Task<IEnumerable<EvaluationModel>> GetAllEvaluationsAsync();
        Task<EvaluationModel> GetEvaluationByIdAsync(int id);
        Task CreateEvaluationAsync(EvaluationModel evaluation);
        Task UpdateEvaluationAsync(EvaluationModel evaluation);
        Task DeleteEvaluationAsync(int id);
    }
}
