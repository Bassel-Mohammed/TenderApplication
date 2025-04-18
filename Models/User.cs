using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tender_management.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Tender> Tenders { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}

