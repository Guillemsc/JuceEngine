using JuceEngine.Core.Tick.Services;
using JuceEngine.InmediateModeUi.UseCases;
using JuceEngine.Renderer.UseCases;
using JuceEngine.Window.UseCases;

namespace JuceEngine.General.UseCases
{
    public sealed class TickUseCase
    {
        readonly ITickablesService _tickableService;
        readonly PumpWindowEventsUseCase _pumpWindowEventsUseCase;
        readonly RenderUseCase _renderUseCase;
        readonly UpdateInmediateModeUiUseCase _updateImGuiUseCase;

        public TickUseCase(
            ITickablesService tickableService,
            PumpWindowEventsUseCase pumpWindowEventsUseCase,
            RenderUseCase renderUseCase,
            UpdateInmediateModeUiUseCase updateImGuiUseCase
            )
        {
            _tickableService = tickableService;
            _pumpWindowEventsUseCase = pumpWindowEventsUseCase;
            _renderUseCase = renderUseCase;
            _updateImGuiUseCase = updateImGuiUseCase;
        }

        public void Execute()
        {
            _pumpWindowEventsUseCase.Execute();
            _updateImGuiUseCase.Execute();

            _tickableService.Tick();

            _renderUseCase.Execute();
        }
    }
}
