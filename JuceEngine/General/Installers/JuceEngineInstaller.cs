using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Installers;
using JuceEngine.Editor.General.Installers;
using JuceEngine.ImmediateModeUi.Installers;
using JuceEngine.Project.Installers;
using JuceEngine.Renderer.Installers;
using JuceEngine.Renderers.General.Installers;
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
            builder.InstallRenderers();
            builder.InstallProject();
            builder.InstallResources();
            builder.InstallInmediateModeUi();
            builder.InstallEditor();
        }
    }
}
