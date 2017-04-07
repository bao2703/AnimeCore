using System;
using System.Threading.Tasks;
using Entities;
using Repositories.Repositories;

namespace Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }
        IGenreRepository GenreRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly NeptuneContext _context;

        public UnitOfWork(NeptuneContext context, IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _context = context;
            MovieRepository = movieRepository;
            GenreRepository = genreRepository;
        }

        public IMovieRepository MovieRepository { get; }

        public IGenreRepository GenreRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}