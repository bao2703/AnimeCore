using System.Collections.Generic;
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
        Movie GetMovieWithGenres(int id);
        IEnumerable<Movie> GetAllMovieWithGenres();
        IEnumerable<Movie> GetAllMovieWithGenres(string searchString);
        IEnumerable<Movie> FindNewestMovie(int take);
        IEnumerable<Movie> FindPopularMovie(int take);
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

        public Movie GetMovieWithGenres(int id)
        {
            return DbSet.Include(x => x.GenreMovies).ThenInclude(x => x.Genre).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> GetAllMovieWithGenres()
        {
            return DbSet.Include(x => x.GenreMovies).ThenInclude(x => x.Genre);
        }

        public IEnumerable<Movie> GetAllMovieWithGenres(string searchString)
        {
            return DbSet.Include(x => x.GenreMovies).Where(x => x.Name.Contains(searchString));
        }

        public IEnumerable<Movie> FindNewestMovie(int take)
        {
            return DbSet.OrderByDescending(x => x.Release).Take(take);
        }

        public IEnumerable<Movie> FindPopularMovie(int take)
        {
            return DbSet.OrderByDescending(x => x.Views).Take(take);
        }
    }
}