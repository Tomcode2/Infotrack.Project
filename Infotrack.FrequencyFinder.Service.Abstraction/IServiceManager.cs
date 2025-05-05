namespace Infotrack.FrequencyFinder.Service.Abstraction
{
    /// <summary>
    /// Interface for service manager.
    /// </summary>
    public interface IServiceManager
    {
        ISearchService SearchServiceMgr { get; }
    }
}
