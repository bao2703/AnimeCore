﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Customer : TimestampEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}