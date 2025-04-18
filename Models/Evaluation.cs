using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using System;
using System.ComponentModel.DataAnnotations;

namespace Tender_management.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        public int BidId { get; set; }

        public int EvaluatorId { get; set; }

        public decimal Score { get; set; }

        public string Comments { get; set; }

        public DateTime EvaluatedAt { get; set; } = DateTime.UtcNow;

        public Bid Bid { get; set; }

        public User Evaluator { get; set; }
    }
}
