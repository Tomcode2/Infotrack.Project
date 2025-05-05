using Infotrack.FrequencyFinder.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Core.Repositories
{
    /// <summary>
    /// Repository interface for Search entity.
    /// </summary>
    public interface ISearchRepository : IRepository<Search>
    {
        Task<IEnumerable<Search>> GetAllSearchAsync();
        Task<Search> GetSearchByIdAsync(int id);
        void Save(Search search);
    }
}
