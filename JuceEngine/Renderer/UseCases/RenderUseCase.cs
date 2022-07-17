using ImGuiNET;
using JuceEngine.Core.Repositories;
using JuceEngine.InmediateModeUi.UseCases;
using Veldrid;

namespace JuceEngine.Renderer.UseCases
{
    public sealed class RenderUseCase
    {
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly IReadOnlySingleRepository<CommandList> _commandListRepository;
        readonly RenderInmediateModeUiUseCase _renderImGuiUseCase;

        public RenderUseCase(
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository,
            IReadOnlySingleRepository<CommandList> commandListRepository,
            RenderInmediateModeUiUseCase renderImGuiUseCase
            )
        {
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _commandListRepository = commandListRepository;
            _renderImGuiUseCase = renderImGuiUseCase;
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

            // Draw whatever you want here.
            if (ImGui.Begin("Test Window"))
            {
                ImGui.Text("Hello");
            }
            ImGui.End();


            commandList.Begin();
            commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
            commandList.ClearColorTarget(0, new RgbaFloat(0, 0, 0.2f, 1f));

            _renderImGuiUseCase.Execute(graphicsDevice, commandList);

            commandList.End();

            graphicsDevice.SubmitCommands(commandList);
            graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
        }
    }
}
