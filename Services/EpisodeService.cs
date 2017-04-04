using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;

namespace Services
{
    public interface IEpisodeService
    {
        Episode FindBy(int id);
        List<Episode> OrderByName(IEnumerable<Episode> episodes);
    }

    public class EpisodeService : IEpisodeService
    {
        private readonly NeptuneContext _context;

        public EpisodeService(NeptuneContext context)
        {
            _context = context;
        }

        public Episode FindBy(int id)
        {
            return _context.Episodes.Find(id);
        }

        public List<Episode> OrderByName(IEnumerable<Episode> episodes)
        {
            return episodes.OrderBy(x => x.Name.Length).ThenBy(x => x.Name).ToList();
        }
    }
}