using JuceEngine.Core.Di.Builder;
using JuceEngine.Project.Data;
using JuceEngine.Resources.Data;
using JuceEngine.Resources.UseCases;

namespace JuceEngine.Services.Installers
{
    public static class ResourcesInstaller
    {
        public static void InstallResources(this IDiContainerBuilder builder)
        {
            builder.Bind<ResourcesData>().FromNew();

            builder.Bind<AddResourceUseCase>()
                .FromFunction(c => new AddResourceUseCase(
                    c.Resolve<ResourcesData>().ResourcesRepository
                ));

            builder.Bind<SaveResourceMetaUseCase>()
                .FromFunction(c => new SaveResourceMetaUseCase(
                 ));

            builder.Bind<TryLoadResourceMetaUseCase>()
                .FromFunction(c => new TryLoadResourceMetaUseCase(
                 ));

            builder.Bind<LoadResourceUseCase>()
                .FromFunction(c => new LoadResourceUseCase(
                    c.Resolve<LoadTextureResourceUseCase>()
                ));

            builder.Bind<LoadTextureResourceUseCase>()
                .FromFunction(c => new LoadTextureResourceUseCase(
                    c.Resolve<AddResourceUseCase>(),
                    c.Resolve<TryLoadResourceMetaUseCase>(),
                    c.Resolve<SaveResourceMetaUseCase>()

                ));

            builder.Bind<LoadProjectResourcesUseCase>()
                .FromFunction(c => new LoadProjectResourcesUseCase(
                    c.Resolve<ProjectData>(),
                    c.Resolve<LoadResourceUseCase>()
                ));
        }
    }
}
