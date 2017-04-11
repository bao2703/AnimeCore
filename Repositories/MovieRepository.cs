using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IEnumerable<Movie> FindByNameContains(string searchString);
        IEnumerable<Movie> FindNewestMovie(int take);
        IEnumerable<Movie> FindPopularMovie(int take);
        bool IsPopular(int id);
        bool IsNewest(int id);
    }

    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(NeptuneContext context) : base(context)
        {
        }

        public override Movie FindById(object id)
        {
            return DbSet.Include(x => x.Episodes)
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre)
                .SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<Movie> GetAll()
        {
            return DbSet.Include(x => x.Episodes)
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre);
        }

        public IEnumerable<Movie> FindByNameContains(string searchString)
        {
            return DbSet.Include(x => x.GenreMovies)
                .Where(x => x.Name.Contains(searchString));
        }

        public IEnumerable<Movie> FindNewestMovie(int take)
        {
            return DbSet.OrderByDescending(x => x.Release).Take(take);
        }

        public IEnumerable<Movie> FindPopularMovie(int take)
        {
            return DbSet.OrderByDescending(x => x.View).Take(take);
        }

        public bool IsPopular(int id)
        {
            return FindPopularMovie(16).Any(x => x.Id == id);
        }

        public bool IsNewest(int id)
        {
            return FindNewestMovie(16).Any(x => x.Id == id);
        }
    }
}