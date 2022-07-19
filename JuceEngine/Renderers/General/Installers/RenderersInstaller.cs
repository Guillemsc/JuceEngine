using JuceEngine.Core.Di.Builder;
using JuceEngine.Renderers.General.UseCases;
using JuceEngine.Renderers.TestTriangle.Installers;
using JuceEngine.Renderers.TestTriangle.UseCases;

namespace JuceEngine.Renderers.General.Installers
{
    public static class RenderersInstaller
    {
        public static void InstallRenderers(this IDiContainerBuilder builder)
        {
            builder.InstallTestTriangle();

            builder.Bind<LoadRenderersUseCase>()
                .FromFunction(c => new LoadRenderersUseCase(
                    c.Resolve<LoadTestTriangleRendererUseCase>()
                ));

            builder.Bind<RenderRenderersUseCase>()
                .FromFunction(c => new RenderRenderersUseCase(
                    c.Resolve<RenderTestTriangleRendererUseCase>()
                ));
        }
    }
}
