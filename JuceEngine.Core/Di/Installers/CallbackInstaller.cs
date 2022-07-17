using System;
using JuceEngine.Core.Di.Builder;

namespace JuceEngine.Core.Di.Installers
{
    public sealed class CallbackInstaller : IInstaller
    {
        readonly Action<IDiContainerBuilder> _callback;

        public CallbackInstaller(
            Action<IDiContainerBuilder> callback
            )
        {
            _callback = callback;
        }

        public void Install(IDiContainerBuilder container)
        {
            _callback.Invoke(container);
        }
    }
}
