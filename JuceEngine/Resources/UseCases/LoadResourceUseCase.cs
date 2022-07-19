using JuceEngine.Core.Results.Tasks;
using JuceEngine.Resources.Meta;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Resources.UseCases
{
    public sealed class LoadResourceUseCase
    {
        readonly LoadTextureResourceUseCase _loadTextureResourceUseCase;

        public LoadResourceUseCase(
            LoadTextureResourceUseCase loadTextureResourceUseCase
            )
        {
            _loadTextureResourceUseCase = loadTextureResourceUseCase;
        }

        public Task Execute(string resourceFilePath, CancellationToken cancellationToken)
        {
            bool exists = File.Exists(resourceFilePath);

            if(!exists)
            {
                return Task.CompletedTask;
            }

            string extension = Path.GetExtension(resourceFilePath);

            if(extension != ".png")
            {
                return Task.CompletedTask;
            }

            return _loadTextureResourceUseCase.Execute(resourceFilePath, cancellationToken);
        }
    }
}
