using Infotrack.FrequencyFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Api.Resources
{
    /// <summary>
    /// Represents a search resource.
    /// </summary>
    public class SearchResource
    {
        public SearchResource()
        {
        }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public string SearchRank { get; set; }
        public DateTime SearchOn { get; set; }
        public string SearchBy { get; set; }
    }
}
