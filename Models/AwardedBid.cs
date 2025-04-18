using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;

namespace Tender_management.Models
{
    public class AwardedBid
    {
        [Key]
        public int AwardId { get; set; }

        public int TenderId { get; set; }

        public int WinningBidId { get; set; }

        public DateTime AwardedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Awarded";

        public Tender Tender { get; set; }

        public Bid WinningBid { get; set; }
    }
}
