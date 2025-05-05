using Infotrack.FrequencyFinder.Web.Validation;

namespace Infotrack.FrequencyFinder.Test
{
    [TestClass]
    public class PatternVerifierTests
    {
        private readonly PatternVerifier _patternVerifier;

        public PatternVerifierTests()
        {
            _patternVerifier = new PatternVerifier();
        }

        [TestMethod]
        public void ValidateQuery_ValidInput_ReturnsTrue()
        {
            // Arrange  
            string validInput = "land search";

            // Act  
            bool result = _patternVerifier.ValidateQuery(validInput);

            // Assert  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateQuery_InvalidInput_ReturnsFalse()
        {
            // Arrange  
            string invalidInput = "DROP TABLE Users";
            // Act  
            bool result = _patternVerifier.ValidateQuery(invalidInput);

            // Assert  
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateUrl_ValidUrl_ReturnsTrue()
        {
            // Arrange  
            string validUrl = "https://www.example.com";

            // Act  
            bool result = _patternVerifier.ValidateUrl(validUrl);

            // Assert  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateUrl_InvalidUrl_ReturnsFalse()
        {
            // Arrange  
            string invalidUrl = "htp:/invalid-url";

            // Act  
            bool result = _patternVerifier.ValidateUrl(invalidUrl);

            // Assert  
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateRequestHeaders_ValidHeaders_ReturnsTrue()
        {
            // Arrange  
            var headers = new Dictionary<string, string>
           {
               { "Content-Type", "application/json" },
               { "Authorization", "Bearer token" }
           };

            // Act  
            bool result = _patternVerifier.ValidateRequestHeaders(headers);

            // Assert  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateRequestHeaders_InvalidHeaders_ReturnsFalse()
        {
            // Arrange  
            var headers = new Dictionary<string, string>
           {
               { "Invalid Key", "Value" }
           };
            
            // Act  
            bool result = _patternVerifier.ValidateRequestHeaders(headers);

            // Assert  
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateRequestBody_ValidJson_ReturnsTrue()
        {
            // Arrange  
            string validJson = "{\"key\":\"value\"}";

            // Act  
            bool result = _patternVerifier.ValidateRequestBody(validJson);

            // Assert  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateRequestBody_InvalidJson_ReturnsFalse()
        {
            // Arrange  
            string invalidJson = "{key:value}";

            // Act  
            bool result = _patternVerifier.ValidateRequestBody(invalidJson);

            // Assert  
            Assert.IsFalse(result);
        }
    }
}
