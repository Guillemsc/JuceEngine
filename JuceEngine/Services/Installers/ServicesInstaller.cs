using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Services;

namespace JuceEngine.Services.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder builder)
        {
            builder.Bind<ITickablesService>()
                .FromFunction(c => new TickablesService(
                ));
        }
    }
}
