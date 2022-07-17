using System;
using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Tick.Enums;
using JuceEngine.Core.Tick.Services;
using JuceEngine.Core.Tick.Tickables;

namespace JuceEngine.Di.Extensions
{
    public static class DiTickablesExtensions
    {
        public static IDiBindingActionBuilder<T> LinkToTickablesService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            TickType tickType = TickType.Update
            )
            where T : ITickable
        {
            actionBuilder.WhenInit((c, o) =>
            {
                ITickablesService tickablesService = c.Resolve<ITickablesService>();

                tickablesService.Add(o, tickType);
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                ITickablesService tickablesService = c.Resolve<ITickablesService>();

                tickablesService.RemoveNow(o, tickType);
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }

        public static IDiBindingActionBuilder<T> LinkToTickablesService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Func<T, Action> func,
            TickType tickType = TickType.Update
            )
        {
            CallbackTickable callbackTickable = null;

            actionBuilder.WhenInit((c, o) =>
            {
                Action action = func.Invoke(o);

                callbackTickable = new CallbackTickable(action);

                ITickablesService tickablesService = c.Resolve<ITickablesService>();

                tickablesService.Add(callbackTickable, tickType);
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                ITickablesService tickablesService = c.Resolve<ITickablesService>();

                tickablesService.RemoveNow(callbackTickable, tickType);
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }
    }
}
