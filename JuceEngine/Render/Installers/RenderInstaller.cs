using JuceEngine.Core.Di.Builder;
using JuceEngine.Render.Data;
using JuceEngine.Render.UseCases;
using JuceEngine.Window.Data;

namespace JuceEngine.Render.Installers
{
    public static class RenderInstaller
    {
        public static void InstallRender(this IDiContainerBuilder builder)
        {
            builder.Bind<RenderData>().FromNew();

            builder.Bind<CreateGraphicsDeviceUseCase>()
                .FromFunction(c => new CreateGraphicsDeviceUseCase(
                    c.Resolve<WindowData>().WindowRepository,
                    c.Resolve<RenderData>().GraphicsDeviceRepository
                ));
        }
    }
}
