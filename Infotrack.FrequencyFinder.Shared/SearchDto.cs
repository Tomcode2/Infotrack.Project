namespace Infotrack.FrequencyFinder.Shared
{
    public class SearchDto
    {
        public SearchDto()
        {
        }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public string SearchRank { get; set; }
        public DateTime SearchOn { get; set; }
        public string SearchBy { get; set; }
    }
    
}
