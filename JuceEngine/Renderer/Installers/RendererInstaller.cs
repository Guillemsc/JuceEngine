using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Enums;
using JuceEngine.Di.Extensions;
using JuceEngine.InmediateModeUi.UseCases;
using JuceEngine.Renderer.Data;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Window.Data;
using JuceEngine.Window.UseCases;

namespace JuceEngine.Renderer.Installers
{
    public static class RendererInstaller
    {
        public static void InstallRenderer(this IDiContainerBuilder builder)
        {
            builder.Bind<RendererData>().FromNew();

            builder.Bind<CreateRendererUseCase>()
                .FromFunction(c => new CreateRendererUseCase(
                    c.Resolve<WindowData>().GraphicsDeviceRepository,
                    c.Resolve<RendererData>().CommandListRepository
                ));

            builder.Bind<RenderUseCase>()
                .FromFunction(c => new RenderUseCase(
                    c.Resolve<WindowData>().GraphicsDeviceRepository,
                    c.Resolve<RendererData>().CommandListRepository,
                    c.Resolve<RenderInmediateModeUiUseCase>()
                ));
        }
    }
}
