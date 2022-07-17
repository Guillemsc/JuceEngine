using JuceEngine.Core.Di.Container;

namespace JuceEngine.Core.Di.BindingActions
{
    public sealed class ActionWithContainerBindingAction : IDiBindingAction
    {
        readonly Action<IDiResolveContainer, object> _action;

        public ActionWithContainerBindingAction(Action<IDiResolveContainer, object> action)
        {
            _action = action;
        }

        public void Execute(IDiResolveContainer resolver, object obj)
        {
            _action?.Invoke(resolver, obj);
        }
    }
}
