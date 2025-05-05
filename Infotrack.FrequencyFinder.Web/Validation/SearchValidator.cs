using Infotrack.FrequencyFinder.Web.DTO;

namespace Infotrack.FrequencyFinder.Web.Validation
{
    /// <summary>
    /// Validator for search inputs.
    /// </summary>
    public class SearchValidator : ISearchValidator
    {
        public bool Validate(SearchDto search, out Dictionary<string, string> validationErrors)
        {
            validationErrors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(search.SearchQuery))
            {
                validationErrors.Add(nameof(search.SearchQuery), "Search query cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(search.SearchEngine))
            {
                validationErrors.Add(nameof(search.SearchEngine), "Search engine must be specified.");
            }

            var validEngines = new[] { Constants.Google, Constants.Bing, Constants.Yahoo };
            if (!validEngines.Contains(search.SearchEngine))
            {
                validationErrors.Add(nameof(search.SearchEngine), "Invalid search engine specified.");
            }

            return !validationErrors.Any();
        }
    }

    public interface ISearchValidator
    {
        public bool Validate(SearchDto search, out Dictionary<string, string> validationErrors);
    }
}
