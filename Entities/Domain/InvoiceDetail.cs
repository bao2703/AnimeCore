using System;

namespace Entities.Domain
{
    public class InvoiceDetail
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }

        public long View { get; set; }

        public long Hover { get; set; }

        public long Click { get; set; }

        public long Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}