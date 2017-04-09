using System.Collections.Generic;

namespace Entities.Domain
{
    public abstract class Advertisement : TimestampEntity
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}