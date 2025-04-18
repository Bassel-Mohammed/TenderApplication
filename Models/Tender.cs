using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tender_management.Models
{
    public class Tender
    {
        [Key]
        public int TenderId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Type { get; set; } // Open, Restricted, Single Source

        public decimal BudgetRange { get; set; }

        public DateTime Deadline { get; set; }

        public int ProcurementOfficerId { get; set; }

        public string Status { get; set; } = "Open";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User ProcurementOfficer { get; set; }

        public ICollection<Bid> Bids { get; set; }

        public ICollection<AwardedBid> AwardedBids { get; set; }
    }
}
