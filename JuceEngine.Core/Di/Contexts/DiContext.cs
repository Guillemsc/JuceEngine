using JuceEngine.Core.Di.Container;
using JuceEngine.Core.Di.Extensions;
using JuceEngine.Core.Di.Installers;
using JuceEngine.Core.Disposables;

namespace JuceEngine.Core.Di.Contexts
{
    public sealed class DiContext<TResult> : IDiContext<TResult>
    {
        readonly IInstaller[] _installers;

        public DiContext(params IInstaller[] installers)
        {
            _installers = installers;
        }

        public IDisposable<TResult> Install()
        {
            IDiContainer container = DiContainerBuilderExtensions.BuildFromInstallers(_installers);

            void Dispose(TResult result)
            {
                container.Dispose();
            }

            TResult result = container.Resolve<TResult>();

            return new CallbackDisposable<TResult>(
                result,
                Dispose
            );
        }
    }
}
