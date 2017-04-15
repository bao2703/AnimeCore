using System.Collections.Generic;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
    }

    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(NeptuneContext context) : base(context)
        {
        }

        public override IEnumerable<Invoice> GetAll()
        {
            return DbSet.Include(x => x.InvoiceDetails)
                .Include(x => x.Customer);
        }
    }
}