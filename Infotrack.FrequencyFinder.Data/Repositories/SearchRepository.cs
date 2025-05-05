using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Data.Repositories
{
    /// <summary>
    /// Search repository implementation for CRUD operations.
    /// </summary>
    public class SearchRepository : Repository<Search>, ISearchRepository
    {
        public SearchRepository(SearchDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Search>> GetAllSearchAsync()
        {
            return await SearchDbContext.Search
               .Include(m => m.Id)
               .ToListAsync();
        }

        public async Task<Search> GetSearchByIdAsync(int id)
        {
            return await SearchDbContext.Search    
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Save(Search search)
        {
            throw new NotImplementedException();
        }

        private SearchDbContext SearchDbContext
        {
            get { return Context as SearchDbContext; }
        }
    }
}
