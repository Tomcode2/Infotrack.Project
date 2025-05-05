using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Shared
{
    public class SearchForCreationDto
    {
        public SearchForCreationDto()
        {

        }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public string SearchRank { get; set; }
        public DateTime SearchOn { get; set; } 
        public string SearchB { get; set; }
    }
}
