using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Domain;

namespace Services
{
    public interface IGenreService
    {
        Genre FindBy(int id);
        Task<Genre> FindByAsync(int id);
        void Add(Genre genre);
        Task UpdateAsync(Genre genre);
        Task RemoveAsync(Genre genre);
        List<Genre> ToList();
    }

    public class GenreService : IGenreService
    {
        private readonly NeptuneContext _context;

        public GenreService(NeptuneContext context)
        {
            _context = context;
        }

        public Genre FindBy(int id)
        {
            return _context.Genres.Find(id);
        }

        public async Task<Genre> FindByAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public List<Genre> ToList()
        {
            return _context.Genres.OrderBy(x => x.Name).ToList();
        }
    }
}