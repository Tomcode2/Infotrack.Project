using Infotrack.FrequencyFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infotrack.FrequencyFinder.Data.Configurations
{
    public class SearchConfiguration : IEntityTypeConfiguration<Search>
    {
        /// <summary>
        /// Configures the Search entity.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Search> builder)
        {
            builder
                .ToTable(nameof(Search));

            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.SearchQuery)
                .IsRequired()
            .HasMaxLength(100);

            builder
                .Property(m => m.SearchEngine)
            .HasMaxLength(100);

            builder
                .Property(m => m.SearchRank)
                .HasMaxLength(100);

            builder
                .Property(m => m.SearchOn)
                .HasColumnType("datetime");

            builder
                .Property(m => m.SearchBy)
                .HasMaxLength(100);

        }
    }
}
