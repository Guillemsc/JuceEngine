using JuceEngine.Core.Tick.Services;
using JuceEngine.ImmediateModeUi.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Window.UseCases;

namespace JuceEngine.General.UseCases
{
    public sealed class TickUseCase
    {
        readonly ITickablesService _tickableService;
        readonly PumpWindowEventsUseCase _pumpWindowEventsUseCase;
        readonly TryResizeRendererUseCase _tryResizeRendererUseCase;
        readonly RenderUseCase _renderUseCase;
        readonly UpdateImmediateModeUiUseCase _updateImGuiUseCase;

        public TickUseCase(
            ITickablesService tickableService,
            PumpWindowEventsUseCase pumpWindowEventsUseCase,
            TryResizeRendererUseCase tryResizeRendererUseCase,
            RenderUseCase renderUseCase,
            UpdateImmediateModeUiUseCase updateImGuiUseCase
            )
        {
            _tickableService = tickableService;
            _pumpWindowEventsUseCase = pumpWindowEventsUseCase;
            _tryResizeRendererUseCase = tryResizeRendererUseCase;
            _renderUseCase = renderUseCase;
            _updateImGuiUseCase = updateImGuiUseCase;
        }

        public void Execute()
        {
            _pumpWindowEventsUseCase.Execute();
            _updateImGuiUseCase.Execute();

            _tickableService.Tick();

            _tryResizeRendererUseCase.Execute();
            _renderUseCase.Execute();
        }
    }
}
