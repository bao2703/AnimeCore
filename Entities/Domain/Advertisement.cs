using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Domain
{
    public abstract class Advertisement : Entity, IValidatableObject
    {
        protected Advertisement()
        {
            StartDate = DateTime.Today;
            EndDate = StartDate.Add(TimeSpan.FromDays(1));
        }

        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Source { get; set; }

        public string Description { get; set; }

        public long View { get; set; }

        public long Click { get; set; }

        public long Price { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int? AdsLocationId { get; set; }

        public AdsLocation AdsLocation { get; set; }

        [NotMapped]
        public AdsStatus Status
        {
            get
            {
                if (EndDate < DateTime.Today)
                {
                    return AdsStatus.Expired;
                }
                if (StartDate > DateTime.Today)
                {
                    return AdsStatus.Idle;
                }
                return AdsStatus.Active;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (EndDate <= StartDate)
            {
                result.Add(new ValidationResult("End date must be greater than start date.", new[] {"EndDate"}));
            }

            return result;
        }
    }
}