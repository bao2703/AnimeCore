using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Invoice : TimestampEntity
    {
        public Invoice()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        public long TotalPrice { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}