﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Customer : Entity
    {
        public Customer()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [RegularExpression("(\\+84|0)\\d{9,10}", ErrorMessage = "The {0} is not valid.")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}