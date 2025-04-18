using Microsoft.EntityFrameworkCore;
using Tender_management.Models;

namespace Tender_management.Infrastructure
{
    public class EFCoreDBContext : DbContext
    {
        

        // DbSets for each table/entity
        public DbSet<User> Users { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }  // Added Evaluations
        public DbSet<AwardedBid> AwardedBids { get; set; }  // Added AwardedBids


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4PANH4P\\SQLEXPRESS;Database=TenderManagement;Integrated Security=True;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Tender (Procurement Officer)
            modelBuilder.Entity<Tender>()
                .HasOne(t => t.ProcurementOfficer)
                .WithMany(u => u.Tenders)
                .HasForeignKey(t => t.ProcurementOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tender - Bid
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Tender)
                .WithMany(t => t.Bids)
                .HasForeignKey(b => b.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Bid (Bidder)
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Bidder)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade path issue


            // Bid - Evaluation
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Bid)
                .WithMany()
                .HasForeignKey(e => e.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Evaluation (Evaluator)
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Evaluator)
                .WithMany()
                .HasForeignKey(e => e.EvaluatorId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade conflict

            // AwardedBid - Tender
            modelBuilder.Entity<AwardedBid>()
                .HasOne(ab => ab.Tender)
                .WithMany(t => t.AwardedBids)
                .HasForeignKey(ab => ab.TenderId)
                .OnDelete(DeleteBehavior.Restrict); // important to avoid cascade path

            // AwardedBid - Bid
            modelBuilder.Entity<AwardedBid>()
                .HasOne(ab => ab.WinningBid)
                .WithMany(b => b.AwardedBids)
                .HasForeignKey(ab => ab.WinningBidId)
                .OnDelete(DeleteBehavior.Restrict); //restrict cascade
        }

    }
}