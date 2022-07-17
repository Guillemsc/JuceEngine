using JuceEngine.Core.Di.Container;

namespace JuceEngine.Core.Di.BindingActions
{
    public interface IDiBindingAction
    {
        void Execute(IDiResolveContainer resolver, object obj);
    }
}
