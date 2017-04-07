using System;
using System.Threading.Tasks;
using Entities;
using Repositories.Repositories;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly NeptuneContext _context;

        public UnitOfWork(NeptuneContext context, IMovieRepository movieRepository)
        {
            _context = context;
            MovieRepository = movieRepository;
        }

        public IMovieRepository MovieRepository { get; }

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