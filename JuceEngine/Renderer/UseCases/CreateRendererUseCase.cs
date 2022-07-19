using JuceEngine.Core.Repositories;
using System;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace JuceEngine.Renderer.UseCases
{
    public sealed class CreateRendererUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;
        readonly ISingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly ISingleRepository<CommandList> _commandListRepository;

        public CreateRendererUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository,
            ISingleRepository<GraphicsDevice> graphicsDeviceRepository,
            ISingleRepository<CommandList> commandListRepository
            )
        {
            _windowRepository = windowRepository;
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _commandListRepository = commandListRepository;
        }

        public void Execute()
        {
            bool hasWindow = _windowRepository.TryGet(out Sdl2Window window);

            if(!hasWindow)
            {
                Console.WriteLine($"Tried to create Graphics device, " +
                    $"but {nameof(Sdl2Window)} could not be found");
                return;
            }

            GraphicsDevice graphicsDevice = VeldridStartup.CreateGraphicsDevice(window);

            CommandList commandList = graphicsDevice.ResourceFactory.CreateCommandList();

            _graphicsDeviceRepository.Set(graphicsDevice);
            _commandListRepository.Set(commandList);
        }
    }
}
