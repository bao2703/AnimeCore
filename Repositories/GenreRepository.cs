using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IGenreRepository : IRepositoryAsync<Genre>
    {
    }

    public class GenreRepository : RepositoryAsync<Genre>, IGenreRepository
    {
        public GenreRepository(NeptuneContext context) : base(context)
        {
        }
    }
}