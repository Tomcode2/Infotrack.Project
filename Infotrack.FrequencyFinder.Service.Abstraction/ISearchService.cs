using Infotrack.FrequencyFinder.Core.Entities;

namespace Infotrack.FrequencyFinder.Service.Abstraction
{
    /// <summary>
    /// Interface for search service.
    /// </summary>
    public interface ISearchService
    {
        Task<IEnumerable<Search>> GetSearches();
        Task<Search> GetSearchById(int id);
        Task<Search> SaveSearch(Search newSearch);
    }
}
