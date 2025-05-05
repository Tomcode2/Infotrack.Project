using AutoMapper;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Service.Abstraction;
using Infotrack.FrequencyFinder.Web.DTO;
using Infotrack.FrequencyFinder.Web.EngineService;
using Infotrack.FrequencyFinder.Web.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infotrack.FrequencyFinder.Web.Controllers
{
    /// <summary>
    /// Controller for managing search operations.
    /// </summary>
    public class SearchController : Controller
    {
        /// <summary>
        /// The search service for handling search-related operations.
        /// </summary>
        private readonly ISearchService _searchService;
        /// <summary>
        /// The logger for logging information and errors.
        /// </summary>
        private readonly ILogger<SearchController> _logger;
        /// <summary>
        /// The mapper for mapping between entities and DTOs.
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The search validator for validating search inputs.
        /// </summary>
        private readonly ISearchValidator _searchValidator;
        /// <summary>
        /// The search engine factory for creating search engine instances.
        /// </summary>
        private readonly ISearchEngineFactory _searchEngineFactory;

        public SearchController(
            ISearchService searchService,
            IMapper mapper,
            ILogger<SearchController> logger,
            ISearchValidator searchValidator,
            ISearchEngineFactory searchEngineFactory)
        {
            _mapper = mapper;
            _searchService = searchService;
            _logger = logger;
            _searchValidator = searchValidator;
            _searchEngineFactory = searchEngineFactory;
        }

        /// <summary>
        /// Displays the index view with a list of searches.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                var searchEngines = GetSearchEngines();
                ViewBag.SearchEngines = searchEngines;

                var searches = await GetAllSearches();
                var searchRanks = GetSearchRanks(searches);
                var searchRanksDates = GetSearchRanksDates(searches);

                ViewBag.SearchRanks = searchRanks;
                ViewBag.SearchRanksDates = searchRanksDates;

                _logger.LogInformation("Fetched searches successfully. Total searches: {SearchCount}, Search Engines: {SearchEngines}", searches.Count(), string.Join(", ", searchEngines.Select(e => e.Text)));

                return View(searches);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching searches.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Search engines for the search form.
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetSearchEngines()
        {
            return new List<SelectListItem>
               {
                   new SelectListItem { Text = Constants.Google, Value = Constants.Google, Selected = true },
                   new SelectListItem { Text = Constants.Bing, Value = Constants.Bing },
                   new SelectListItem { Text = Constants.Yahoo, Value = Constants.Yahoo }
               };
        }

        /// <summary>
        /// Gets the search ranks for the specified searches.
        /// </summary>
        /// <param name="searches"></param>
        /// <returns></returns>
        private IEnumerable<dynamic> GetSearchRanks(IEnumerable<SearchDto> searches)
        {
            return searches
                .Where(s => s.SearchEngine == Constants.Google)
                .Select(s => new
                {
                    Engine = s.SearchEngine,
                    Ranks = s.SearchRank?.Split(", ").Select(rank =>
                    {
                        if (int.TryParse(rank, out int parsedRank))
                            return parsedRank;
                        return 0;
                    }).ToList() ?? new List<int>()
                })
                .ToList();
        }

        /// <summary>
        /// Gets the search ranks dates for the specified searches.
        /// </summary>
        /// <param name="searches"></param>
        /// <returns></returns>
        private IEnumerable<dynamic> GetSearchRanksDates(IEnumerable<SearchDto> searches)
        {
            return searches
                .Where(s => s.SearchEngine == Constants.Google)
                .Select(s => new
                {
                    DatesDataSet = s.SearchOn?.ToString("dd-MMM-yy")
                })
                .ToList();
        }

        /// <summary>
        /// Gets all searches from the search service.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SearchDto>> GetAllSearches()
        {
            var searches = await _searchService.GetSearches();
            var searchResources = _mapper.Map<IEnumerable<Search>, IEnumerable<SearchDto>>(searches);
            return searchResources.OrderByDescending(x => x.SearchOn);
        }


        /// <summary>
        /// Saves the search from the user input.
        /// </summary>
        /// <param name="searchFromUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveSearch(SearchDto searchFromUser)
        {
            if (!_searchValidator.Validate(searchFromUser, out var validationErrors))
            {
                foreach (var error in validationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
                return View(searchFromUser);
            }

            try
            {
                var searchEngine = _searchEngineFactory.Create(searchFromUser.SearchEngine);
                var uri = searchEngine.GetEngineUri(searchFromUser.SearchQuery);
                var content = await searchEngine.ProcessSearchAsync(uri);

                var searchToCreate = _mapper.Map<SearchDto, Search>(searchFromUser);
                searchToCreate.SearchOn = DateTime.Now;
                searchToCreate.SearchBy = "WebUser";

                var ranks = searchEngine.GetSearchRank(content, new Uri("https://www.infotrack.co.uk"));
                searchToCreate.SearchRank = ranks != null && ranks.Any() ? string.Join(", ", ranks) : "Not Found";

                await _searchService.SaveSearch(searchToCreate);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving searches.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while processing your request.");
                return View(searchFromUser);
            }
        }
    }
}
