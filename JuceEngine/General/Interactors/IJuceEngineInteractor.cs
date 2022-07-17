using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.Interactors
{
    public interface IJuceEngineInteractor
    {
        bool Quit { get; }

        Task Load(CancellationToken cancellationToken);
        void Tick();
    }
}
