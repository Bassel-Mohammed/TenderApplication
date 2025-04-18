using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tender_management.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }

        public int TenderId { get; set; }

        public int BidderId { get; set; }

        public decimal BidAmount { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Tender Tender { get; set; }

        public User Bidder { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<AwardedBid> AwardedBids { get; set; }
    }
}
