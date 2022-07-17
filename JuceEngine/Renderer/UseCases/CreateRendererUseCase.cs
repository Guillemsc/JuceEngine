using JuceEngine.Core.Repositories;
using System;
using Veldrid;

namespace JuceEngine.Renderer.UseCases
{
    public sealed class CreateRendererUseCase
    {
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly ISingleRepository<CommandList> _commandListRepository;

        public CreateRendererUseCase(
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository,
            ISingleRepository<CommandList> commandListRepository
            )
        {
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _commandListRepository = commandListRepository;
        }

        public void Execute()
        {
            bool hasGraphicsDevice = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if (!hasGraphicsDevice)
            {
                Console.WriteLine($"Tried to create Renderer, but {nameof(GraphicsDevice)} could not " +
                    $"be found");
                return;
            }

            CommandList commandList = graphicsDevice.ResourceFactory.CreateCommandList();

            _commandListRepository.Set(commandList);
        }
    }
}
