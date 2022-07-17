using JuceEngine.Core.Di.Builder;
using JuceEngine.Di.Extensions;
using JuceEngine.InmediateModeUi.Data;
using JuceEngine.InmediateModeUi.UseCases;
using JuceEngine.Window.Data;

namespace JuceEngine.InmediateModeUi.Installers
{
    public static class ImGuiInstaller
    {
        public static void InstallInmediateModeUi(this IDiContainerBuilder builder)
        {
            builder.Bind<InmediateModeUiData>().FromNew();

            builder.Bind<SetupInmediateModeUiUseCase>()
                .FromFunction(c => new SetupInmediateModeUiUseCase(
                    c.Resolve<WindowData>().GraphicsDeviceRepository,
                    c.Resolve<InmediateModeUiData>().InmediateModeUiRendererRepository
                ));

            builder.Bind<UpdateInmediateModeUiUseCase>()
                .FromFunction(c => new UpdateInmediateModeUiUseCase(
                    c.Resolve<WindowData>().CurrentFrameInputSnapshotRepository,
                    c.Resolve<InmediateModeUiData>().InmediateModeUiRendererRepository
                ));

            builder.Bind<RenderInmediateModeUiUseCase>()
                .FromFunction(c => new RenderInmediateModeUiUseCase(
                     c.Resolve<InmediateModeUiData>().InmediateModeUiRendererRepository
                ));
        }
    }
}
