using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Disposables;

namespace JuceEngine.Core.Di.Installers
{
    public interface IInstaller
    {
        void Install(IDiContainerBuilder builder);
    }
}
