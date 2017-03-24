using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;

namespace Services
{
    public interface IGenreService
    {
        List<Genre> ToList();
    }

    public class GenreService : IGenreService
    {
        private readonly NeptuneContext _context;

        public GenreService(NeptuneContext context)
        {
            _context = context;
        }

        public List<Genre> ToList()
        {
            return _context.Genres.OrderBy(x => x.Name).ToList();
        }
    }
}