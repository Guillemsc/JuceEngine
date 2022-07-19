using JuceEngine.General.UseCases;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.Interactors
{
    public class JuceEngineInteractor : IJuceEngineInteractor
    {
        readonly LoadUseCase _loadUseCase;
        readonly TickUseCase _tickUseCase;
        readonly WantsToQuitUseCase _wantsToQuitUseCase;

        public JuceEngineInteractor(
            LoadUseCase loadUseCase,
            TickUseCase tickUseCase,
            WantsToQuitUseCase wantsToQuitUseCase
            )
        {
            _loadUseCase = loadUseCase;
            _tickUseCase = tickUseCase;
            _wantsToQuitUseCase = wantsToQuitUseCase;
        }

  
        public Task Load(CancellationToken cancellationToken)
        {
            return _loadUseCase.Execute(cancellationToken);
        }

        public void Tick()
        {
            _tickUseCase.Execute();
        }

        public bool WantsToQuit()
        {
            return _wantsToQuitUseCase.Execute(); 
        }
    }
}
