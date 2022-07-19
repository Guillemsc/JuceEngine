using JuceEngine.Core.Di.Builder;
using JuceEngine.Project.Data;
using JuceEngine.Project.UseCases;

namespace JuceEngine.Project.Installers
{
    public static class ProjectInstaller
    {
        public static void InstallProject(this IDiContainerBuilder builder)
        {
            builder.Bind<ProjectData>().FromNew();

            builder.Bind<SetProjectPathUseCase>()
                .FromFunction(c => new SetProjectPathUseCase(
                    c.Resolve<ProjectData>()
                ));

            builder.Bind<GetFullPathFromLocalProjectPathUseCase>()
                .FromFunction(c => new GetFullPathFromLocalProjectPathUseCase(
                    c.Resolve<ProjectData>()
                 ));
        }
    }
}
