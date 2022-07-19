using JuceEngine.Core.Results.Tasks;
using JuceEngine.Resources.Meta;
using JuceEngine.Serialization.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Resources.UseCases
{
    public sealed class SaveResourceMetaUseCase
    {
        public async Task Execute<TMeta>(
            string resourceFilePath,
            TMeta meta,
            CancellationToken cancellationToken
            ) where TMeta : IMeta
        {
            string finalPath = $"{resourceFilePath}.meta";

            await SerializableObject.Save<TMeta>(finalPath, meta, cancellationToken);
        }
    }
}
