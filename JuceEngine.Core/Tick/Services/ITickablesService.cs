using JuceEngine.Core.Tick.Enums;
using JuceEngine.Core.Tick.Tickables;

namespace JuceEngine.Core.Tick.Services
{
    public interface ITickablesService : ITickable
    {
        void Add(ITickable tickable, TickType tickType);
        void Remove(ITickable tickable, TickType tickType);
        void RemoveNow(ITickable tickable, TickType tickType);
    }
}
