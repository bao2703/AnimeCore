using System.Collections.Generic;

namespace Entities.Domain
{
    public class Invoice : TimestampEntity
    {
        public long TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}