using Infotrack.FrequencyFinder.Core.Exceptions;
using Infotrack.FrequencyFinder.Web;
using Infotrack.FrequencyFinder.Web.EngineService;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Infotrack.FrequencyFinder.Test
{
    public class SearchEngineFactoryTest
    {
        private ISearchEngineFactory? _searchEngineFactory;
        private Mock<IServiceProvider>? _mockServiceProvider;
        [TestInitialize]
        public void Setup()
        {
            _mockServiceProvider = new Mock<IServiceProvider>();
            _searchEngineFactory = new SearchEngineFactory(_mockServiceProvider.Object);
        }
        [TestMethod]
        public void Create_ShouldReturnGoogleEngineService_WhenGoogleIsProvided()
        {
            // Arrange
            var searchEngineName = Constants.Google;
            var googleEngineService = new Mock<GoogleEngineService>();
            _mockServiceProvider!.Setup(sp => sp.GetRequiredService<GoogleEngineService>()).Returns(googleEngineService.Object);
            // Act
            var result = _searchEngineFactory!.Create(searchEngineName);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GoogleEngineService));
        }
        [TestMethod]
        public void Create_ShouldThrowSearchInvalidException_WhenInvalidSearchEngineIsProvided()
        {
            // Arrange
            var searchEngineName = "InvalidSearchEngine";
            // Act & Assert
            Assert.ThrowsException<SearchInvalidException>(() => _searchEngineFactory!.Create(searchEngineName));
        }
    }
}
