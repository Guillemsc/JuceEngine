using ImGuiNET;
using JuceEngine.Core.Repositories;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Renderers.General.UseCases;
using Veldrid;

namespace JuceEngine.Renderer.UseCases
{
    public sealed class RenderUseCase
    {
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly IReadOnlySingleRepository<CommandList> _commandListRepository;
        readonly RenderImmediateModeUiUseCase _renderImGuiUseCase;
        readonly RenderRenderersUseCase _renderRenderersUseCase;

        public RenderUseCase(
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository,
            IReadOnlySingleRepository<CommandList> commandListRepository,
            RenderImmediateModeUiUseCase renderImGuiUseCase,
            RenderRenderersUseCase renderRenderersUseCase
            )
        {
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _commandListRepository = commandListRepository;
            _renderImGuiUseCase = renderImGuiUseCase;
            _renderRenderersUseCase = renderRenderersUseCase;
        }

        public void Execute()
        {
            bool graphicsDeviceFound = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if(!graphicsDeviceFound)
            {
                return;
            }

            bool commandListFound = _commandListRepository.TryGet(out CommandList commandList);

            if(!commandListFound)
            {
                return;
            }

            commandList.Begin();
            commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
            commandList.ClearColorTarget(0, new RgbaFloat(0, 0, 0.2f, 1f));

            _renderRenderersUseCase.Execute(graphicsDevice, commandList);
            _renderImGuiUseCase.Execute(graphicsDevice, commandList);

            commandList.End();

            graphicsDevice.SubmitCommands(commandList);
            graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
        }
    }
}
