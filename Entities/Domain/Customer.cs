using System.Collections.Generic;

namespace Entities.Domain
{
    public class Customer : TimestampEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}