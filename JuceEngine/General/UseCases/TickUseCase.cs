using JuceEngine.Core.Tick.Services;

namespace JuceEngine.General.UseCases
{
    public sealed class TickUseCase
    {
        readonly ITickablesService _tickableService;

        public TickUseCase(ITickablesService tickableService)
        {
            _tickableService = tickableService;
        }

        public void Execute()
        {
            _tickableService.Tick();
        }
    }
}
