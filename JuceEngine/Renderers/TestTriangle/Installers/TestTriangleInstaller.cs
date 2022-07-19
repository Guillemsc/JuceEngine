using JuceEngine.Core.Di.Builder;
using JuceEngine.Renderer.Data;
using JuceEngine.Renderers.TestTriangle.Data;
using JuceEngine.Renderers.TestTriangle.UseCases;

namespace JuceEngine.Renderers.TestTriangle.Installers
{
    public static class TestTriangleInstaller
    {
        public static void InstallTestTriangle(this IDiContainerBuilder builder)
        {
            builder.Bind<TestTriangleData>().FromNew();

            builder.Bind<LoadTestTriangleRendererUseCase>()
                .FromFunction(c => new LoadTestTriangleRendererUseCase(
                    c.Resolve<TestTriangleData>(),
                    c.Resolve<RendererData>().GraphicsDeviceRepository
                ));

            builder.Bind<RenderTestTriangleRendererUseCase>()
                .FromFunction(c => new RenderTestTriangleRendererUseCase(
                    c.Resolve<TestTriangleData>()
                ));

            builder.Bind<UnloadTestTriangleRendererUseCase>()
                .FromFunction(c => new UnloadTestTriangleRendererUseCase(
                      c.Resolve<TestTriangleData>()
                 ))
                .WhenDispose(o => o.Execute)
                .NonLazy();
        }
    }
}
