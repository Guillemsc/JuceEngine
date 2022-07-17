using JuceEngine.General.UseCases;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.Interactors
{
    public class JuceEngineInteractor : IJuceEngineInteractor
    {
        readonly LoadUseCase _loadUseCase;
        readonly TickUseCase _tickUseCase;

        public JuceEngineInteractor(
            LoadUseCase loadUseCase,
            TickUseCase tickUseCase
            )
        {
            _loadUseCase = loadUseCase;
            _tickUseCase = tickUseCase;
        }

        public bool Quit { get; }

        public Task Load(CancellationToken cancellationToken)
        {
            return _loadUseCase.Execute(cancellationToken);
        }

        public void Tick()
        {
            _tickUseCase.Execute();
        }
    }
}
