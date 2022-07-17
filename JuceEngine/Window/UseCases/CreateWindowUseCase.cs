using JuceEngine.Core.Repositories;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace JuceEngine.Window.UseCases
{
    public sealed class CreateWindowUseCase
    {
        readonly ISingleRepository<Sdl2Window> _windowRepository;
        readonly ISingleRepository<GraphicsDevice> _graphicsDeviceRepository;

        public CreateWindowUseCase(
            ISingleRepository<Sdl2Window> windowRepository,
            ISingleRepository<GraphicsDevice> graphicsDeviceRepository
            )
        {
            _windowRepository = windowRepository;
            _graphicsDeviceRepository = graphicsDeviceRepository;
        }

        public void Execute()
        {
            WindowCreateInfo windowCreateInfo = new WindowCreateInfo()
            {
                X = 100,
                Y = 100,
                WindowWidth = 960,
                WindowHeight = 540,
                WindowTitle = "Veldrid Tutorial"
            };

            VeldridStartup.CreateWindowAndGraphicsDevice(
                windowCreateInfo,
                out Sdl2Window window,
                out GraphicsDevice graphicsDevice
                );

            _windowRepository.Set(window);
            _graphicsDeviceRepository.Set(graphicsDevice);
        }
    }
}
