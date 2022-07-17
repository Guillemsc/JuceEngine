using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.BindingActions
{
    public sealed class ActionWithoutContainerBindingAction : IDiBindingAction
    {
        readonly Action<object> _action;

        public ActionWithoutContainerBindingAction(Action<object> action)
        {
            _action = action;
        }

        public void Execute(IDiResolveContainer resolver, object obj)
        {
            _action?.Invoke(obj);
        }
    }
}
