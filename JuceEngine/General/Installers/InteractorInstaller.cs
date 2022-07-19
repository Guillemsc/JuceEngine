using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Services;
using JuceEngine.General.Interactors;
using JuceEngine.General.UseCases;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Project.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Renderers.General.UseCases;
using JuceEngine.Resources.UseCases;
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
                    c.Resolve<SetupImmediateModeUiUseCase>(),
                    c.Resolve<SetProjectPathUseCase>(),
                    c.Resolve<LoadProjectResourcesUseCase>(),
                    c.Resolve<LoadRenderersUseCase>()
                ));

            builder.Bind<TickUseCase>()
                .FromFunction(c => new TickUseCase(
                    c.Resolve<ITickablesService>(),
                    c.Resolve<PumpWindowEventsUseCase>(),
                    c.Resolve<TryResizeRendererUseCase>(),
                    c.Resolve<RenderUseCase>(),
                    c.Resolve<UpdateImmediateModeUiUseCase>()
                ));

            builder.Bind<WantsToQuitUseCase>()
                .FromFunction(c => new WantsToQuitUseCase(
                    c.Resolve<IsWindowClosedUseCase>()
                ));

            builder.Bind<IJuceEngineInteractor>()
                .FromFunction(c => new JuceEngineInteractor(
                    c.Resolve<LoadUseCase>(),
                    c.Resolve<TickUseCase>(),
                    c.Resolve<WantsToQuitUseCase>()
                ));
        }
    }
}
