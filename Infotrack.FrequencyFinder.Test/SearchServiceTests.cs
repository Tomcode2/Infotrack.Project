using Infotrack.FrequencyFinder.Core;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Services;
using Moq;

namespace Infotrack.FrequencyFinder.Test
{
    [TestClass]
    public class SearchServiceTests
    {
        private SearchService? _searchService;
        private Mock<IUnitOfWork>? _mockUnitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _searchService = new SearchService(_mockUnitOfWork.Object);
        }

        [TestMethod]
        public async Task GetSearches_ShouldReturnAllSearches()
        {
            // Arrange  
            var mockSearches = new List<Search>
            {
                new Search { Id = 1, SearchQuery = "test1", SearchEngine = "Google" },
                new Search { Id = 2, SearchQuery = "test2", SearchEngine = "Bing" }
            };
            _mockUnitOfWork!.Setup(u => u.SearchRepoUnitOfWork.GetAllAsync()).ReturnsAsync(mockSearches);

            // Act  
            var result = await _searchService!.GetSearches();

            // Assert  
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("test1", result.First().SearchQuery);
        }

        [TestMethod]
        public async Task GetSearches_ShouldReturnEmptyList_WhenNoSearchesExist()
        {
            // Arrange  
            _mockUnitOfWork!.Setup(u => u.SearchRepoUnitOfWork.GetAllAsync()).ReturnsAsync(new List<Search>());

            // Act  
            var result = await _searchService!.GetSearches();

            // Assert  
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
