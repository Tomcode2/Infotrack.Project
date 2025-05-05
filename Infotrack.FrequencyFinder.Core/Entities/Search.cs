using System;

namespace Infotrack.FrequencyFinder.Core.Entities
{
    /// <summary>
    /// Represents a search entity.
    /// </summary>
    public class Search
    {
        public Search()
        {
        }
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public string SearchRank { get; set; }
        public DateTime? SearchOn { get; set; }
        public string SearchBy { get; set; }
         
    }
}
