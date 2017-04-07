using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories.Repositories
{
    public interface IMovieRepository : IRepositoryAsync<Movie>
    {
        Movie GetMovieWithEpisodes(int id);
    }

    public class MovieRepository : RepositoryAsync<Movie>, IMovieRepository
    {
        public MovieRepository(NeptuneContext context) : base(context)
        {
        }

        public Movie GetMovieWithEpisodes(int id)
        {
            return DbSet.Include(x => x.Episodes).SingleOrDefault(x => x.Id == id);
        }
    }
}