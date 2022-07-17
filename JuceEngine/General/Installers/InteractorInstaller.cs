using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Services;
using JuceEngine.General.Interactors;
using JuceEngine.General.UseCases;
using JuceEngine.InmediateModeUi.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Window.UseCases;

namespace JuceEngine.General.Installers
{
    public static class InteractorInstaller
    {
        public static void InstallInteractor(this IDiContainerBuilder builder)
        {
            builder.Bind<LoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    c.Resolve<CreateWindowUseCase>(),
                    c.Resolve<CreateRendererUseCase>(),
                    c.Resolve<SetupInmediateModeUiUseCase>()
                ));

            builder.Bind<TickUseCase>()
                .FromFunction(c => new TickUseCase(
                    c.Resolve<ITickablesService>(),
                    c.Resolve<PumpWindowEventsUseCase>(),
                    c.Resolve<RenderUseCase>(),
                    c.Resolve<UpdateInmediateModeUiUseCase>()
                ));

            builder.Bind<IJuceEngineInteractor>()
                .FromFunction(c => new JuceEngineInteractor(
                    c.Resolve<LoadUseCase>(),
                    c.Resolve<TickUseCase>()
                ));
        }
    }
}
