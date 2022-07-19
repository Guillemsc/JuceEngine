using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Extensions;
using JuceEngine.Editor.General.UseCases;
using JuceEngine.ImmediateModeUi.Data;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Renderer.Data;
using JuceEngine.Window.Data;

namespace JuceEngine.ImmediateModeUi.Installers
{
    public static class ImmediateModeUiInstaller
    {
        public static void InstallInmediateModeUi(this IDiContainerBuilder builder)
        {
            builder.Bind<ImmediateModeUiData>().FromNew();

            builder.Bind<SetupImmediateModeUiUseCase>()
                .FromFunction(c => new SetupImmediateModeUiUseCase(
                    c.Resolve<RendererData>().GraphicsDeviceRepository,
                    c.Resolve<ImmediateModeUiData>().ImmediateModeUiRendererRepository,
                    c.Resolve<WindowSizeData>()
                ));

            builder.Bind<ResizeImmediateModeUiUseCase>()
                .FromFunction(c => new ResizeImmediateModeUiUseCase(
                     c.Resolve<ImmediateModeUiData>().ImmediateModeUiRendererRepository,
                     c.Resolve<RendererData>().GraphicsDeviceRepository
                ));

            builder.Bind<UpdateImmediateModeUiUseCase>()
                .FromFunction(c => new UpdateImmediateModeUiUseCase(
                    c.Resolve<WindowData>().CurrentFrameInputSnapshotRepository,
                    c.Resolve<ImmediateModeUiData>().ImmediateModeUiRendererRepository,
                    c.Resolve<DrawEditorUseCase>()
                ));

            builder.Bind<RenderImmediateModeUiUseCase>()
                .FromFunction(c => new RenderImmediateModeUiUseCase(
                     c.Resolve<ImmediateModeUiData>().ImmediateModeUiRendererRepository
                ));
        }
    }
}
