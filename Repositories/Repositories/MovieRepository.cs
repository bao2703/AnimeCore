using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories.Repositories
{
    public interface IMovieRepository : IRepositoryAsync<Movie>
    {
    }

    public class MovieRepository : RepositoryAsync<Movie>, IMovieRepository
    {
        public MovieRepository(NeptuneContext context) : base(context)
        {
        }
    }
}