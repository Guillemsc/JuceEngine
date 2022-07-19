using JuceEngine.Core.Di.Builder;
using JuceEngine.Window.Data;
using JuceEngine.Window.UseCases;

namespace JuceEngine.Window.Installers
{
    public static class WindowInstaller
    {
        public static void InstallWindow(this IDiContainerBuilder builder)
        {
            builder.Bind<WindowData>().FromNew();
            builder.Bind<WindowSizeData>().FromNew();

            builder.Bind<WindowResizedUseCase>()
                .FromFunction(c => new WindowResizedUseCase(
                      c.Resolve<WindowData>().WindowRepository,
                      c.Resolve<WindowSizeData>()
                ));

            builder.Bind<CreateWindowUseCase>()
                .FromFunction(c => new CreateWindowUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                    c.Resolve<WindowResizedUseCase>()
                ));

            builder.Bind<PumpWindowEventsUseCase>()
                .FromFunction(c => new PumpWindowEventsUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                    c.Resolve<WindowData>().CurrentFrameInputSnapshotRepository
                ));

            builder.Bind<IsWindowClosedUseCase>()
                .FromFunction(c => new IsWindowClosedUseCase(
                     c.Resolve<WindowData>().WindowRepository
                ));
        }
    }
}
