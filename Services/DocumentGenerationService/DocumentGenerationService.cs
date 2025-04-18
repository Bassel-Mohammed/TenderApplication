using Microsoft.EntityFrameworkCore.Metadata;
using Tender_management.Models;

public class DocumentGenerationService
{
    public void GenerateBidDocument(Bid bid)
    {
        // Sample document generation logic for a submitted bid
        Console.WriteLine("Bid Submission Document");
        Console.WriteLine("------------------------");
        Console.WriteLine($"Bid ID: {bid.BidId}");
        Console.WriteLine($"Tender ID: {bid.TenderId}");
        Console.WriteLine($"Bidder: {bid.Bidder.FullName}");
        Console.WriteLine($"Amount: {bid.BidAmount}");
        Console.WriteLine($"Submission Date: {bid.SubmittedAt}");
        Console.WriteLine($"Status: {bid.Status}");
        Console.WriteLine("------------------------");
        Console.WriteLine("End of Document");
    }


    public void GenerateTenderDocument(Tender tender)
    {
        Console.WriteLine("Tender Document");
        Console.WriteLine("----------------");
        Console.WriteLine($"Tender ID: {tender.TenderId}");
        Console.WriteLine($"Tender Title: {tender.Title}");
        Console.WriteLine($"Tender Description: {tender.Description}");
        Console.WriteLine($"Deadline: {tender.Deadline}"); 
        Console.WriteLine("----------------");
        Console.WriteLine("End of Document");
    }
}
