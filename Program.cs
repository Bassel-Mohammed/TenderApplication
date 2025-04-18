using System;
using Microsoft.Extensions.DependencyInjection;
using Tender_management.Infrastructure;
using TenderManagementSystem.Services.Tender;
using TenderManagementSystem.Services.Bid;
using Tender_management.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EFCoreDBContext>() 
            .AddScoped<ITenderService, TenderService>()
            .AddScoped<IBidService, BidService>()
            .AddSingleton<DocumentGenerationService>() // Singleton because it's stateless
            .BuildServiceProvider();

        var tenderService = serviceProvider.GetRequiredService<ITenderService>();
        var docService = serviceProvider.GetRequiredService<DocumentGenerationService>();

        Console.WriteLine("---- Tender Management Console ----");

        // Example: Create a tender
        var newTender = new Tender
        {
            Title = "Build School Infrastructure",
            Description = "Construction of 3 classrooms and a library",
            Category = "Construction",
            Type = "Open",
            BudgetRange = 1500000,
            Deadline = DateTime.UtcNow.AddDays(30),
            ProcurementOfficerId = 1, // Make sure user with this ID exists
            Status = "Open"
        };

        await tenderService.CreateTenderAsync(newTender);

        Console.WriteLine("Tender created successfully.\nGenerating document...\n");

        // Retrieve tender with ID (auto incremented) and generate document
        var tenders = await tenderService.GetAllTendersAsync();
        foreach (var tender in tenders)
        {
            docService.GenerateTenderDocument(tender);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
