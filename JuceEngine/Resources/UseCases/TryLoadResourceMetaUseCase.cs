using JuceEngine.Core.Results.Tasks;
using JuceEngine.Resources.Meta;
using JuceEngine.Serialization.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Resources.UseCases
{
    public sealed class TryLoadResourceMetaUseCase
    {
        public async Task<ITaskResult<TMeta>> Execute<TMeta>(
            string resourceFilePath, 
            CancellationToken cancellationToken
            ) where TMeta : IMeta
        {
            string finalPath = $"{resourceFilePath}.meta";

            return await SerializableObject.Load<TMeta>(finalPath, cancellationToken);
        }
    }
}
