﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum AdsType
    {
        Video,
        Banner
    }

    public class Advertisement : TimestampEntity, IValidatableObject
    {
        public Advertisement()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Source { get; set; }

        [Display(Name = "Ads type")]
        public AdsType AdsType { get; set; }

        public string Description { get; set; }

        public long View { get; set; }

        public long Click { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }

        public int AdsLocationId { get; set; }

        public AdsLocation AdsLocation { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (StartDate < DateTime.Today)
            {
                result.Add(new ValidationResult("Start date must be greater than current date.", new[] {"StartDate"}));
            }

            if (EndDate <= StartDate)
            {
                result.Add(new ValidationResult("End date must be greater than start date.", new[] {"EndDate"}));
            }

            return result;
        }
    }
}