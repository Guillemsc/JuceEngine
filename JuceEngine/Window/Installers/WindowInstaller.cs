using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Enums;
using JuceEngine.Di.Extensions;
using JuceEngine.Window.Data;
using JuceEngine.Window.UseCases;

namespace JuceEngine.Window.Installers
{
    public static class WindowInstaller
    {
        public static void InstallWindow(this IDiContainerBuilder builder)
        {
            builder.Bind<WindowData>().FromNew();

            builder.Bind<CreateWindowUseCase>()
                .FromFunction(c => new CreateWindowUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                     c.Resolve<WindowData>().GraphicsDeviceRepository
                ));

            builder.Bind<PumpWindowEventsUseCase>()
                .FromFunction(c => new PumpWindowEventsUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                     c.Resolve<WindowData>().CurrentFrameInputSnapshotRepository
                ));
        }
    }
}
