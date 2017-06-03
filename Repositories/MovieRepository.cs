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
        IEnumerable<Movie> FindSlide(string[] id);
        void Like(User user, Movie movie);
        void UnLike(User user, Movie movie);
        bool HasLikeTo(User user, Movie movie);
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
                .Include(x => x.Likes)
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre)
                .SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<Movie> GetAll()
        {
            return DbSet.Include(x => x.Episodes)
                .Include(x => x.Likes)
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre);
        }

        public IEnumerable<Movie> FindByNameContains(string searchString)
        {
            return DbSet.Include(x => x.Episodes)
                .Include(x => x.Likes)
                .Include(x => x.GenreMovies)
                .Where(x => x.Name.ToLower().Contains(searchString.ToLower()));
        }

        public IEnumerable<Movie> FindNewestMovie(int take)
        {
            return DbSet.Include(x => x.Episodes).OrderByDescending(x => x.Release).Take(take);
        }

        public IEnumerable<Movie> FindPopularMovie(int take)
        {
            return DbSet.Include(x => x.Episodes).OrderByDescending(x => x.View).Take(take);
        }

        public IEnumerable<Movie> FindSlide(string[] id)
        {
            return id.Select(item => DbSet.Include(x => x.Episodes)
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre)
                .SingleOrDefault(x => x.Id.ToString() == item)).Where(item => item != null).ToList();
        }

        public void Like(User user, Movie movie)
        {
            movie.Likes.Add(new Like
            {
                User = user
            });
        }

        public void UnLike(User user, Movie movie)
        {
            movie.Likes.Remove(movie.Likes.SingleOrDefault(x => x.UserId == user.Id));
        }

        public bool HasLikeTo(User user, Movie movie)
        {
            return movie.Likes.Any(x => x.UserId == user.Id);
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