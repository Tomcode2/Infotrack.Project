namespace Infotrack.FrequencyFinder.Web.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Search entity.
    /// </summary>
    public class SearchDto
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public string? SearchRank { get; set; }
        public DateTime? SearchOn { get; set; }
        public string? SearchBy { get; set; }
    }
    
}
