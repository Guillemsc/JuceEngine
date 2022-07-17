using JuceEngine.InmediateModeUi.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Window.UseCases;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.UseCases
{
    public sealed class LoadUseCase
    {
        readonly CreateWindowUseCase _createWindowUseCase;
        readonly CreateRendererUseCase _createRendererUseCase;
        readonly SetupInmediateModeUiUseCase _setupImGuiUseCase;

        public LoadUseCase(
            CreateWindowUseCase createWindowUseCase,
            CreateRendererUseCase createRendererUseCase,
            SetupInmediateModeUiUseCase setupImGuiUseCase
            )
        {
            _createWindowUseCase = createWindowUseCase;
            _createRendererUseCase = createRendererUseCase;
            _setupImGuiUseCase = setupImGuiUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            _createWindowUseCase.Execute();
            _createRendererUseCase.Execute();
            _setupImGuiUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}
