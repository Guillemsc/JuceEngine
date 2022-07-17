using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Installers;
using JuceEngine.InmediateModeUi.Installers;
using JuceEngine.Renderer.Installers;
using JuceEngine.Services.Installers;
using JuceEngine.Window.Installers;

namespace JuceEngine.General.Installers
{
    public sealed class JuceEngineInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder builder)
        {
            builder.InstallInteractor();
            builder.InstallServices();
            builder.InstallWindow();
            builder.InstallRenderer();
            builder.InstallInmediateModeUi();
        }
    }
}
