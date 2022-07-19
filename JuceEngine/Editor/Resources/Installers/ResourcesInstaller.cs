using JuceEngine.Core.Di.Builder;
using JuceEngine.Editor.Resources.UseCases;
using JuceEngine.Resources.Data;

namespace JuceEngine.Editor.Resources.Installers
{
    public static class ResourcesInstaller
    {
        public static void InstallResources(this IDiContainerBuilder builder)
        {
            builder.Bind<DrawResourcesWindowUseCase>()
                .FromFunction(c => new DrawResourcesWindowUseCase(
                    c.Resolve<ResourcesData>().ResourcesRepository
                    ));
        }
    }
}
