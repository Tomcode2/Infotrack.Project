using Infotrack.FrequencyFinder.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Core
{
    /// <summary>
    /// UnitOfWork interface for managing repositories and committing changes.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ISearchRepository SearchRepoUnitOfWork { get; }
        Task<int> CommitAsync();
    }
}
