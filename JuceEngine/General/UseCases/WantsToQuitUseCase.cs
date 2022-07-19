using JuceEngine.Window.UseCases;

namespace JuceEngine.General.UseCases
{
    public sealed class WantsToQuitUseCase
    {
        readonly IsWindowClosedUseCase _isWindowClosedUseCase;

        public WantsToQuitUseCase(
            IsWindowClosedUseCase isWindowClosedUseCase
            )
        {
            _isWindowClosedUseCase = isWindowClosedUseCase;
        }

        public bool Execute()
        {
            return _isWindowClosedUseCase.Execute();
        }
    }
}
