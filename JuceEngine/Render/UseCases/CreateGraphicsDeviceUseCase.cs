using JuceEngine.Core.Repositories;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace JuceEngine.Render.UseCases
{
    public sealed class CreateGraphicsDeviceUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;
        readonly ISingleRepository<GraphicsDevice> _graphicsDeviceRepository;

        public CreateGraphicsDeviceUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository,
            ISingleRepository<GraphicsDevice> graphicsDeviceRepository
            )
        {
            _windowRepository = windowRepository;
            _graphicsDeviceRepository = graphicsDeviceRepository;
        }

        public void Execute()
        {
            bool windowFound = _windowRepository.TryGet(out Sdl2Window window);

            if(!windowFound)
            {
                return;
            }

            GraphicsDeviceOptions options = new GraphicsDeviceOptions
            {
                PreferStandardClipSpaceYDirection = true,
                PreferDepthRangeZeroToOne = true
            };

            GraphicsDevice graphicsDevice = VeldridStartup.CreateGraphicsDevice(window, options);

            _graphicsDeviceRepository.Set(graphicsDevice);
        }
    }
}
