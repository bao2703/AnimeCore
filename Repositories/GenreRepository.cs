using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
    }

    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(NeptuneContext context) : base(context)
        {
        }
    }
}