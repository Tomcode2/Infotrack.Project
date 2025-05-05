using Infotrack.FrequencyFinder.Core;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Service.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Services
{
    /// <summary>
    /// Service class for managing search operations.
    /// </summary>
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public SearchService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Search> SaveSearch(Search newSearch)
        {
            await _unitOfWork.SearchRepoUnitOfWork
                .AddAsync(newSearch);
            await _unitOfWork.CommitAsync();

            return newSearch;
        }
     
        public async Task<IEnumerable<Search>> GetSearches()
        {
            return await _unitOfWork.SearchRepoUnitOfWork.GetAllAsync();
        }
        public async Task<Search> GetSearchById(int id)
        {
            return await _unitOfWork.SearchRepoUnitOfWork.GetSearchByIdAsync(id);
        }

       
    }
}