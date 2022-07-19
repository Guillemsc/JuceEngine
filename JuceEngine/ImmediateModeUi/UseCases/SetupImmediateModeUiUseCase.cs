using JuceEngine.Core.Maths.Data;
using JuceEngine.Core.Repositories;
using JuceEngine.Window.Data;
using System;
using Veldrid;

namespace JuceEngine.ImmediateModeUi.UseCases
{
    public sealed class SetupImmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly ISingleRepository<ImGuiRenderer> _imGuiRendererRepository;
        readonly WindowSizeData _windowSizeData;

        public SetupImmediateModeUiUseCase(
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository,
            ISingleRepository<ImGuiRenderer> imGuiRendererRepository,
            WindowSizeData windowSizeData
            )
        {
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _imGuiRendererRepository = imGuiRendererRepository;
            _windowSizeData = windowSizeData;
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

            Int2 windowSize = _windowSizeData.Size;

            ImGuiRenderer imGuiRenderer = new ImGuiRenderer(
                graphicsDevice,
                graphicsDevice.MainSwapchain.Framebuffer.OutputDescription,
                (int)graphicsDevice.MainSwapchain.Framebuffer.Width,
                (int)graphicsDevice.MainSwapchain.Framebuffer.Height
            );

            _imGuiRendererRepository.Set(imGuiRenderer);
        }
    }
}
