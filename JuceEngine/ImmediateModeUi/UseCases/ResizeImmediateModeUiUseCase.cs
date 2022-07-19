using JuceEngine.Core.Maths.Data;
using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.ImmediateModeUi.UseCases
{
    public sealed class ResizeImmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<ImGuiRenderer> _imGuiRendererRepository;
        readonly ISingleRepository<GraphicsDevice> _graphicsDeviceRepository;

        public ResizeImmediateModeUiUseCase(
            IReadOnlySingleRepository<ImGuiRenderer> imGuiRendererRepository,
            ISingleRepository<GraphicsDevice> graphicsDeviceRepository
            )
        {
            _imGuiRendererRepository = imGuiRendererRepository;
            _graphicsDeviceRepository = graphicsDeviceRepository;
        }

        public void Execute(Int2 size)
        {
            bool imGuiRendererFound = _imGuiRendererRepository.TryGet(out ImGuiRenderer renderer);

            if (!imGuiRendererFound)
            {
                return;
            }

            bool hasGraphicsDevice = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if (!hasGraphicsDevice)
            {
                return;
            }

            renderer.WindowResized(
                (int)graphicsDevice.MainSwapchain.Framebuffer.Width,
                (int)graphicsDevice.MainSwapchain.Framebuffer.Height
                );
        }
    }
}
