using System.Collections.Generic;
using System.Threading.Tasks;
using TenderModel = Tender_management.Models.Tender;

namespace TenderManagementSystem.Services.Tender
{
    public interface ITenderService
    {
        Task<IEnumerable<TenderModel>> GetAllTendersAsync();
        Task<TenderModel> GetTenderByIdAsync(int id);
        Task CreateTenderAsync(TenderModel tender);
        Task UpdateTenderAsync(TenderModel tender);
        Task DeleteTenderAsync(int id);
    }
}
