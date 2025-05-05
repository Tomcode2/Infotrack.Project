using Infotrack.FrequencyFinder.Core.Exceptions;

namespace Infotrack.FrequencyFinder.Web.EngineService
{
    /// <summary>
    /// Factory class for creating search engine services.
    /// </summary>
    public class SearchEngineFactory : ISearchEngineFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchEngineFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEngineService Create(string searchEngineName)
        {
            return searchEngineName switch
            {
                Constants.Google => _serviceProvider.GetRequiredService<GoogleEngineService>(),
                Constants.Bing => _serviceProvider.GetRequiredService<BingEngineService>(),
                Constants.Yahoo => _serviceProvider.GetRequiredService<YahooEngineService>(),
                _ => throw new SearchInvalidException($"Search engine '{searchEngineName}' is not supported.")
            };
        }
    }

    public interface ISearchEngineFactory
    {
        public IEngineService Create(string searchEngineName);
    }
}
