using System.Threading;
using System.Threading.Tasks;
using JuceEngine.Core.Di.Contexts;
using JuceEngine.Core.Disposables;
using JuceEngine.General.Installers;
using JuceEngine.General.Interactors;

namespace JuceEngine.Services.Installers
{
    static class Program
    {
        static async Task Main()
        {
            IDiContext<IJuceEngineInteractor> juceEngineInteractorContext = new DiContext<IJuceEngineInteractor>(
                new JuceEngineInstaller()
            );

            IDisposable<IJuceEngineInteractor> juceEngineInteractor = juceEngineInteractorContext.Install();

            await juceEngineInteractor.Value.Load(CancellationToken.None);

            while (!juceEngineInteractor.Value.WantsToQuit())
            {
                juceEngineInteractor.Value.Tick();
            }

            juceEngineInteractor.Dispose();

        }
    }
}


