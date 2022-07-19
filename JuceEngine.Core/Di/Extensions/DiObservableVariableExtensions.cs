using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Container;
using JuceEngine.Core.Observables.Commands;
using JuceEngine.Core.Observables.Variables;

namespace JuceEngine.Core.Di.Extensions
{
    public static class DiObservableVariableExtensions
    {
        public static IDiBindingActionBuilder<T> LinkObservableCommand<T, TVariable>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Func<IDiResolveContainer, IObservableVariable<TVariable>> getObservable,
            Func<T, Action<TVariable>> func
            )
        {
            IObservableVariable<TVariable> observableCommand = null;
            Action<TVariable> action = null;

            actionBuilder.WhenInit((c, o) =>
            {
                observableCommand = getObservable.Invoke(c);
                action = func.Invoke(o);

                observableCommand.OnChange += action;
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                observableCommand.OnChange -= action;
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }
    }
}
