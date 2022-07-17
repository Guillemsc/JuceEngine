using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.BindingActions
{
    public sealed class EmptyActionWithouthContainerBindingAction : IDiBindingAction
    {
        readonly Action _action;

        public EmptyActionWithouthContainerBindingAction(Action action)
        {
            _action = action;
        }

        public void Execute(IDiResolveContainer resolver, object obj)
        {
            _action?.Invoke();
        }
    }
}
