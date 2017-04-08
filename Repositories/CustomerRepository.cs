using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NeptuneContext context) : base(context)
        {
        }
    }
}