using JuceEngine.Core.Results.Tasks;
using JuceEngine.Resources.Meta;
using JuceEngine.Resources.Resource;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Resources.UseCases
{
    public sealed class LoadTextureResourceUseCase
    {
        readonly AddResourceUseCase _addResourceUseCase;
        readonly TryLoadResourceMetaUseCase _tryLoadResourceMetaUseCase;
        readonly SaveResourceMetaUseCase _createResourceMetaUseCase;

        public LoadTextureResourceUseCase(
            AddResourceUseCase addResourceUseCase,
            TryLoadResourceMetaUseCase tryLoadResourceMetaUseCase,
            SaveResourceMetaUseCase createResourceMetaUseCase
            )
        {
            _addResourceUseCase = addResourceUseCase;
            _tryLoadResourceMetaUseCase = tryLoadResourceMetaUseCase;
            _createResourceMetaUseCase = createResourceMetaUseCase;
        }

        public async Task Execute(string resourceFilePath, CancellationToken cancellationToken)
        {
             ITaskResult<SimpleMeta> simpleMetaResult = await _tryLoadResourceMetaUseCase.Execute<SimpleMeta>(
                 resourceFilePath, 
                 cancellationToken
                 );

            bool hasResult = simpleMetaResult.TryGetResult(out SimpleMeta simpleMeta);

            if(!hasResult)
            {
                simpleMeta = new SimpleMeta(Guid.NewGuid());
            }

            try
            {
                string name = Path.GetFileName(resourceFilePath);

                Image<Rgba32> image = await Image.LoadAsync<Rgba32>(resourceFilePath, cancellationToken);

                TextureResource textureResource = new TextureResource(
                    simpleMeta.Uid,
                    name,
                    image
                    );

                _addResourceUseCase.Execute(textureResource);
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Exception while trying to load image {exception.Message}");
            }

            if(!hasResult)
            {
                await _createResourceMetaUseCase.Execute(resourceFilePath, simpleMeta, cancellationToken);
            }
        }
    }
}
