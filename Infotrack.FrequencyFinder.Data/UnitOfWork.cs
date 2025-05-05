using Infotrack.FrequencyFinder.Core;
using Infotrack.FrequencyFinder.Core.Repositories;
using Infotrack.FrequencyFinder.Data.Repositories;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Data
{
    /// <summary>
    /// UnitOfWork class that implements IUnitOfWork interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SearchDbContext _context;
        private SearchRepository _searchRepository;

        public ISearchRepository SearchRepoUnitOfWork => _searchRepository = _searchRepository ?? new SearchRepository(_context);

        public UnitOfWork(SearchDbContext context)
        {
            this._context = context;
        }
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}