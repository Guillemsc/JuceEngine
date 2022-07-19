using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.Interactors
{
    public interface IJuceEngineInteractor
    {

        Task Load(CancellationToken cancellationToken);
        void Tick();
        bool WantsToQuit();
    }
}
