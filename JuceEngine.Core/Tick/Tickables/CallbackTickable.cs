using System;

namespace JuceEngine.Core.Tick.Tickables
{
    public sealed class CallbackTickable : ITickable
    {
        readonly Action _tick;

        public CallbackTickable(Action tick)
        {
            _tick = tick;
        }

        public void Tick()
        {
            _tick.Invoke();
        }
    }
}
