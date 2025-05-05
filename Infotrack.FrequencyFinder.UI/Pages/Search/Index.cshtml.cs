using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Data;

namespace Infotrack.FrequencyFinder.UI.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly SearchDbContext _context;

        public IndexModel(SearchDbContext context)
        {
            _context = context;
        }

        public IList<Infotrack.FrequencyFinder.Core.Entities.Search> Searches { get;set; }

        public async Task OnGetAsync()
        {
            Searches = await _context.Search.ToListAsync();
        }
    }
}
