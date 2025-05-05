using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infotrack.FrequencyFinder.Data
{
    /// <summary>
    /// Database context for the search entity.
    /// </summary>
    public class SearchDbContext : DbContext
    {
        public DbSet<Search> Search { get; set; }
        public SearchDbContext(DbContextOptions<SearchDbContext> options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new SearchConfiguration());
        }
    }
}