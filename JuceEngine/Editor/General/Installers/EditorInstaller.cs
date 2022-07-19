using JuceEngine.Core.Di.Builder;
using JuceEngine.Editor.General.UseCases;
using JuceEngine.Editor.Resources.Installers;
using JuceEngine.Editor.Resources.UseCases;

namespace JuceEngine.Editor.General.Installers
{
    public static class EditorInstaller
    {
        public static void InstallEditor(this IDiContainerBuilder builder)
        {
            builder.InstallResources();

            builder.Bind<DrawEditorUseCase>()
                .FromFunction(c => new DrawEditorUseCase(
                    c.Resolve<DrawResourcesWindowUseCase>()
                ));
        }
    }
}
