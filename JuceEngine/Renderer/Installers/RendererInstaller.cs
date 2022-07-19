using JuceEngine.Core.Di.Builder;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Renderer.Data;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Renderers.General.UseCases;
using JuceEngine.Window.Data;

namespace JuceEngine.Renderer.Installers
{
    public static class RendererInstaller
    {
        public static void InstallRenderer(this IDiContainerBuilder builder)
        {
            builder.Bind<RendererData>().FromNew();
            builder.Bind<RendererSizeData>().FromNew();

            builder.Bind<CreateRendererUseCase>()
                .FromFunction(c => new CreateRendererUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                    c.Resolve<RendererData>().GraphicsDeviceRepository,
                    c.Resolve<RendererData>().CommandListRepository
                ));

            builder.Bind<RenderUseCase>()
                .FromFunction(c => new RenderUseCase(
                    c.Resolve<RendererData>().GraphicsDeviceRepository,
                    c.Resolve<RendererData>().CommandListRepository,
                    c.Resolve<RenderImmediateModeUiUseCase>(),
                    c.Resolve<RenderRenderersUseCase>()
                ));

            builder.Bind<TryResizeRendererUseCase>()
                .FromFunction(c => new TryResizeRendererUseCase(
                    c.Resolve<WindowSizeData>(),
                    c.Resolve<RendererSizeData>(),
                    c.Resolve<RendererData>().GraphicsDeviceRepository,
                    c.Resolve<ResizeImmediateModeUiUseCase>()
                ));
        }
    }
}
