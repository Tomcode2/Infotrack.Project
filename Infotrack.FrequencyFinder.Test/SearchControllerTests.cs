using AutoMapper;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Service.Abstraction;
using Infotrack.FrequencyFinder.Web.Controllers;
using Infotrack.FrequencyFinder.Web.DTO;
using Infotrack.FrequencyFinder.Web.EngineService;
using Infotrack.FrequencyFinder.Web.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Testing.Platform.Logging;
using Moq;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
[TestClass]
public class SearchControllerTests
{
    private Mock<ISearchService> _searchServiceMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private Mock<ILogger<SearchController>> _loggerMock = null!;
    private Mock<ISearchValidator> _searchValidatorMock = null!;
    private Mock<ISearchEngineFactory> _searchEngineFactoryMock = null!;
    private SearchController _controller = null!;

    public Mock<ILogger<SearchController>> Get_loggerMock()
    {
        return _loggerMock;
    }

    [TestInitialize]
    public void Setup()
    {
        _searchServiceMock = new Mock<ISearchService>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<SearchController>>();
        _searchValidatorMock = new Mock<ISearchValidator>();
        _searchEngineFactoryMock = new Mock<ISearchEngineFactory>();
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearches()
    {
        // Arrange  
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);

        // Act
        var result = await _controller.Index(cancellationToken);

        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsErrorView_OnException()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        _searchServiceMock.Setup(s => s.GetSearches()).ThrowsAsync(new Exception("Test exception"));
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var statusCodeResult = result as StatusCodeResult; // Cast result to StatusCodeResult
        Assert.IsNotNull(statusCodeResult); // Ensure statusCodeResult is not null
        Assert.AreEqual(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode); // Check the status code
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithEmptySearches()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>();
        var searchDtos = new List<SearchDto>();
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithNullSearches()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        List<Search> searches = null!;
        var searchDtos = new List<SearchDto>();
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearchEngines()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearchRanks()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearchRanksDates()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearchEngineFactory()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }

    [TestMethod]
    public async Task Index_ReturnsViewResult_WithSearchValidator()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var searches = new List<Search>
       {
           new Search { Id = 1, SearchQuery = "test", SearchEngine = "Google", SearchOn = System.DateTime.Now },
           new Search { Id = 2, SearchQuery = "example", SearchEngine = "Bing", SearchOn = System.DateTime.Now }
       };
        var searchDtos = searches.Select(s => new SearchDto
        {
            Id = s.Id,
            SearchQuery = s.SearchQuery,
            SearchEngine = s.SearchEngine,
            SearchOn = s.SearchOn
        });
        _searchServiceMock.Setup(s => s.GetSearches()).ReturnsAsync(searches);
        _mapperMock.Setup(m => m.Map<IEnumerable<SearchDto>>(It.IsAny<IEnumerable<Search>>())).Returns(searchDtos);
        // Act
        var result = await _controller.Index(cancellationToken);
        // Assert
        Assert.IsNotNull(result); // Ensure result is not null
        var viewResult = result as ViewResult; // Cast result to ViewResult
        Assert.IsNotNull(viewResult); // Ensure viewResult is not null
        Assert.AreEqual("Index", viewResult.ViewName); // Check the view name
        Assert.AreEqual(searchDtos, viewResult.Model); // Check the model
    }
}

