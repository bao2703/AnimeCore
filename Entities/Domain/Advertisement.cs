using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public abstract class Advertisement : TimestampEntity, IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }

        public long View { get; set; }

        public long Hover { get; set; }

        public long Click { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (StartDate <= DateTime.Now)
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