using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Project.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Renderers.General.UseCases;
using JuceEngine.Resources.UseCases;
using JuceEngine.Window.UseCases;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.UseCases
{
    public sealed class LoadUseCase
    {
        readonly CreateWindowUseCase _createWindowUseCase;
        readonly CreateRendererUseCase _createRendererUseCase;
        readonly SetupImmediateModeUiUseCase _setupImmediateModeUiUseCase;
        readonly SetProjectPathUseCase _setProjectPathUseCase;
        readonly LoadProjectResourcesUseCase _loadProjectResourcesUseCase;
        readonly LoadRenderersUseCase _loadRenderersUseCase;

        public LoadUseCase(
            CreateWindowUseCase createWindowUseCase,
            CreateRendererUseCase createRendererUseCase,
            SetupImmediateModeUiUseCase setupImmediateModeUiUseCase,
            SetProjectPathUseCase setProjectPathUseCase,
            LoadProjectResourcesUseCase loadProjectResourcesUseCase,
            LoadRenderersUseCase loadRenderersUseCase
            )
        {
            _createWindowUseCase = createWindowUseCase;
            _createRendererUseCase = createRendererUseCase;
            _setupImmediateModeUiUseCase = setupImmediateModeUiUseCase;
            _setProjectPathUseCase = setProjectPathUseCase;
            _loadProjectResourcesUseCase = loadProjectResourcesUseCase;
            _loadRenderersUseCase = loadRenderersUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            _createWindowUseCase.Execute();
            _createRendererUseCase.Execute();
            _setupImmediateModeUiUseCase.Execute();

            _setProjectPathUseCase.Execute(@"C:\Users\guill\Desktop\TestProject\");

            await _loadProjectResourcesUseCase.Execute(cancellationToken);

            _loadRenderersUseCase.Execute();
        }
    }
}
