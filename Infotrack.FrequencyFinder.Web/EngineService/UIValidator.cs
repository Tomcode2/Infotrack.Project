using Infotrack.FrequencyFinder.Web.Validation;

namespace Infotrack.FrequencyFinder.Web.EngineService
{
    /// <summary>
    /// Interface for validating user input.
    /// </summary>
    public interface IUIValidator
    {
        string ValidateInput(string searchQuery);
        bool ValidateLength(string searchQuery);
    }
    public class UIValidator : IUIValidator // Fixed inheritance syntax
    {
        public UIValidator()
        {
        }

        public string ValidateInput(string searchQuery)
        {
            PatternVerifier validator = new PatternVerifier();
            if (!validator.ValidateQuery(searchQuery))
            {
                return "";
            }

            return searchQuery;
        }

        public bool ValidateLength(string searchQuery)
        {
            return searchQuery.Length <= 100;
        }
    }
}
