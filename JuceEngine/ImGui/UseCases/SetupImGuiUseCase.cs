using JuceEngine.Core.Repositories;
using System;
using Veldrid;

namespace JuceEngine.InmediateModeUi.UseCases
{
    public sealed class SetupInmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly ISingleRepository<ImGuiRenderer> _imGuiRendererRepository;

        public SetupInmediateModeUiUseCase(
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository,
            ISingleRepository<ImGuiRenderer> imGuiRendererRepository
            )
        {
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _imGuiRendererRepository = imGuiRendererRepository;
        }

        public void Execute()
        {
            bool hasGraphicsDevice = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if(!hasGraphicsDevice)
            {
                Console.WriteLine($"Tried to setup ImGui, but {nameof(GraphicsDevice)} could not " +
                    $"be found");
                return;
            }

            CommandList commandList = graphicsDevice.ResourceFactory.CreateCommandList();

            ImGuiRenderer imGuiRenderer = new ImGuiRenderer(
                graphicsDevice,
                graphicsDevice.MainSwapchain.Framebuffer.OutputDescription,
                960,
                540
            );

            _imGuiRendererRepository.Set(imGuiRenderer);
        }
    }
}
