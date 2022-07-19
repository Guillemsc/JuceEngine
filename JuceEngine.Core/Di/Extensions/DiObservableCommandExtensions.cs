using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Container;
using JuceEngine.Core.Observables.Commands;

namespace JuceEngine.Core.Di.Extensions
{
    public static class DiObservableCommandExtensions
    {
        public static IDiBindingActionBuilder<T> LinkObservableCommand<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Func<IDiResolveContainer, IObservableCommand> getObservable,
            Func<T, Action> func
            )
        {
            IObservableCommand observableCommand = null;
            Action action = null;

            actionBuilder.WhenInit((c, o) =>
            {
                observableCommand = getObservable.Invoke(c);
                action = func.Invoke(o);

                observableCommand.OnExecute += action;
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                observableCommand.OnExecute -= action;
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }
    }
}
