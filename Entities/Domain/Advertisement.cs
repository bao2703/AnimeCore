using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public abstract class Advertisement : TimestampEntity
    {
        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}