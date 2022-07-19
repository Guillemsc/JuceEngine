using JuceEngine.Core.Results.Tasks;

namespace JuceEngine.Core.Persistence.StorageMethods
{
    public interface IStorageMethod
    {
        Task Save(string localPath, string data, CancellationToken cancellationToken);
        Task<ITaskResult<string>> Load(string localPath, CancellationToken cancellationToken);
    }
}
