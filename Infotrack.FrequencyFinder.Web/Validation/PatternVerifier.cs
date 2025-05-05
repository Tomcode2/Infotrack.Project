using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infotrack.FrequencyFinder.Web.Validation
{
    /// <summary>
    /// Interface for validating user input.
    /// </summary>
    public interface IPatternVerifier
    {
        bool ValidateQuery(string input);
        bool ValidateUrl(string url);
        bool ValidateRequestHeaders(Dictionary<string, string> headers);
        bool ValidateRequestBody(string body);
    }

    public class PatternVerifier : IPatternVerifier
    {
        public bool ValidateQuery(string input)
        {
            string pattern = Constants.InputPattern;

            // Check if input or pattern is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            Regex validRegex = new Regex(pattern);
            if(!validRegex.IsMatch(input))
            {
                return false;
            }

            // Check for SQL injection patterns
            if (!ValidateInjection(input))
            {
                return false;
            }

            // Use the validated regex to check the input
            
            return true;
        }

        public bool ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            string pattern = Constants.UrlPattern;
            Regex regex = new Regex(pattern);
            return regex.IsMatch(url);
        }

        public bool ValidateRequestHeaders(Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0)
            {
                return false;
            }

            foreach (var header in headers)
            {
                if (string.IsNullOrWhiteSpace(header.Key) || string.IsNullOrWhiteSpace(header.Value))
                {
                    return false;
                }

                // Ensure header keys follow HTTP header naming conventions  
                var regex = new Regex(Constants.HeaderKeyPattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(header.Key))
                {
                    return false;
                }

                // Check for potential SQL injection in header values  
                if (!ValidateInjection(header.Value))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateRequestBody(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
            {
                return false;
            }

            // Example: Ensure the body is a valid JSON  
            try
            {
                var jsonDocument = System.Text.Json.JsonDocument.Parse(body);

                // Ensure the JSON is not empty  
                if (jsonDocument.RootElement.ValueKind == System.Text.Json.JsonValueKind.Object &&
                    jsonDocument.RootElement.EnumerateObject().Any())
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateInjection(string value)
        {
            string inputValue = value.ToLower();
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                return false;
            }
            // Check for SQL injection patterns  
            //string sqlInjectionPattern = Constants.HeaderValueSqlInjectionPattern;
            //if (Regex.IsMatch(inputValue, sqlInjectionPattern, RegexOptions.IgnoreCase))
            //{
            //    return false;
            //}

            var regex = new Regex(Constants.HeaderValueSqlInjectionPattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(inputValue))
            {
                return false; // Invalid query
            }

            // Check for multiple XSS patterns  
            string[] xssPatterns = new string[] { Constants.HeaderValueXssPattern1, Constants.HeaderValueXssPattern2, Constants.HeaderValueXssPattern3, Constants.HeaderValueXssPattern4,
            Constants.HeaderValueXssPattern5,Constants.HeaderValueXssPattern6,Constants.HeaderValueXssPattern7,Constants.HeaderValueXssPattern8,Constants.HeaderValueXssPattern9,Constants.HeaderValueXssPattern10,Constants.HeaderValueXssPattern11}; // Assume this is an array of patterns  
            foreach (var xssPattern in xssPatterns)
            {
                regex = new Regex(xssPattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(inputValue))
                {
                    return false;
                }
            }

            // Check for Command Injection patterns  
            regex = new Regex(Constants.HeaderValueCommandInjectionPattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(inputValue))
            {
                return false;
            }

            // Check for LDAP Injection patterns  
            regex = new Regex(Constants.HeaderValueLdapInjectionPattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(inputValue))
            {
                return false;
            }

            // Check for XPath Injection patterns  
            regex = new Regex(Constants.HeaderValueXpathInjectionPattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(inputValue))
            {
                return false;
            }
            return true;
        }
    }
}
