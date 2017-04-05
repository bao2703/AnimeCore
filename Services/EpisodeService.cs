using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Domain;

namespace Services
{
    public interface IEpisodeService
    {
        Episode FindBy(int id);
        Task<Episode> FindByAsync(int id);
        Task AddAsync(Episode episode);
        Task UpdateAsync(Episode episode);
        Task RemoveAsync(Episode episode);
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

        public async Task<Episode> FindByAsync(int id)
        {
            return await _context.Episodes.FindAsync(id);
        }

        public async Task AddAsync(Episode episode)
        {
            _context.Attach(episode.Movie);
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Episode episode)
        {
            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
        }

        public List<Episode> OrderByName(IEnumerable<Episode> episodes)
        {
            return episodes.OrderBy(x => x.Name.Length).ThenBy(x => x.Name).ToList();
        }
    }
}