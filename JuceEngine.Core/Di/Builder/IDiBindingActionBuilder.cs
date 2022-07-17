using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.Builder
{
    public interface IDiBindingActionBuilder<T>
    {
        Type IdentifierType { get; }
        Type ActualType { get; }

        IDiBindingActionBuilder<T> NonLazy();
        IDiBindingActionBuilder<T> WhenInit(Action<IDiResolveContainer, T> action);
        IDiBindingActionBuilder<T> WhenInit(Func<T, Action> func);
        IDiBindingActionBuilder<T> WhenDispose(Action<IDiResolveContainer, T> action);
        IDiBindingActionBuilder<T> WhenDispose(Action<T> func);
        IDiBindingActionBuilder<T> WhenDispose(Func<T, Action> func);
        IDiBindingActionBuilder<T> WhenDispose(IDisposable disposable);
    }
}
