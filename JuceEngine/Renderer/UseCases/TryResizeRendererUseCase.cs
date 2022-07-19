using JuceEngine.Core.Repositories;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Renderer.Data;
using JuceEngine.Window.Data;
using Veldrid;
using Veldrid.Sdl2;

namespace JuceEngine.Renderer.UseCases
{
    public sealed class TryResizeRendererUseCase
    {
        readonly WindowSizeData _windowSizeData;
        readonly RendererSizeData _rendererSizeData;
        readonly ISingleRepository<GraphicsDevice> _graphicsDeviceRepository;
        readonly ResizeImmediateModeUiUseCase _resizeImmediateModeUiUseCase;

        public TryResizeRendererUseCase(
            WindowSizeData windowSizeData,
            RendererSizeData rendererSizeData,
            ISingleRepository<GraphicsDevice> graphicsDeviceRepository,
            ResizeImmediateModeUiUseCase resizeImmediateModeUiUseCase
            )
        {
            _windowSizeData = windowSizeData;
            _rendererSizeData = rendererSizeData;
            _graphicsDeviceRepository = graphicsDeviceRepository;
            _resizeImmediateModeUiUseCase = resizeImmediateModeUiUseCase;
        }

        public void Execute()
        {
            bool sizeChanged = _windowSizeData.Size != _rendererSizeData.Size;

            if(!sizeChanged)
            {
                return;
            }

            bool graphicsDeviceFound = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if (!graphicsDeviceFound)
            {
                return;
            }

            _rendererSizeData.Size = _windowSizeData.Size;

            graphicsDevice.ResizeMainWindow(
                (uint)_rendererSizeData.Size.X,
                (uint)_rendererSizeData.Size.Y
                );

            _resizeImmediateModeUiUseCase.Execute(_rendererSizeData.Size);
        }
    }
}
