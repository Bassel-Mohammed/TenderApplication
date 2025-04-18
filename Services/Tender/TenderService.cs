using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender_management.Models;
using Tender_management.Infrastructure;
using TenderModel = Tender_management.Models.Tender;

namespace TenderManagementSystem.Services.Tender
{
    public class TenderService : ITenderService
    {
        private readonly EFCoreDBContext _context;
        private readonly DocumentGenerationService _documentService;

        // Inject DocumentGenerationService
        public TenderService(EFCoreDBContext context, DocumentGenerationService documentService)
        {
            _context = context;
            _documentService = documentService;
        }

        public async Task<IEnumerable<TenderModel>> GetAllTendersAsync()
        {
            return await _context.Tenders.ToListAsync();
        }

        public async Task<TenderModel> GetTenderByIdAsync(int id)
        {
            return await _context.Tenders.FindAsync(id);
        }

        public async Task CreateTenderAsync(TenderModel tender)
        {
            await _context.Tenders.AddAsync(tender);
            await _context.SaveChangesAsync();

            // Generate the tender document after creating the tender
            _documentService.GenerateTenderDocument(tender);
        }

        public async Task UpdateTenderAsync(TenderModel tender)
        {
            _context.Tenders.Update(tender);
            await _context.SaveChangesAsync();

            // Generate the updated tender document after updating the tender
            _documentService.GenerateTenderDocument(tender);
        }

        public async Task DeleteTenderAsync(int id)
        {
            var tender = await _context.Tenders.FindAsync(id);
            if (tender != null)
            {
                _context.Tenders.Remove(tender);
                await _context.SaveChangesAsync();

                Console.WriteLine($"Tender with ID {id} has been deleted.");
            }
        }
    }
}
