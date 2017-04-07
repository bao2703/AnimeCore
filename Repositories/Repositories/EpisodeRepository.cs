using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories.Repositories
{
    public interface IEpisodeRepository : IRepositoryAsync<Episode>
    {
        IEnumerable<Episode> OrderByName(IEnumerable<Episode> episodes);
        IEnumerable<Episode> OrderByDescendingName(IEnumerable<Episode> episodes);
    }

    public class EpisodeRepository : RepositoryAsync<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(NeptuneContext context) : base(context)
        {
        }

        public IEnumerable<Episode> OrderByName(IEnumerable<Episode> episodes)
        {
            return episodes.OrderBy(x => x.Name.Length).ThenBy(x => x.Name);
        }

        public IEnumerable<Episode> OrderByDescendingName(IEnumerable<Episode> episodes)
        {
            return episodes.OrderByDescending(x => x.Name.Length).ThenByDescending(x => x.Name);
        }
    }
}