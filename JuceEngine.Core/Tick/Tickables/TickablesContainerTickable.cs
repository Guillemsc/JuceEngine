using JuceEngine.Core.Tick.Services;

namespace JuceEngine.Core.Tick.Tickables
{
    public sealed class TickablesContainerTickable : ITickable
    {
        readonly List<ITickable> _tickablesToAdd = new List<ITickable>();
        readonly List<ITickable> _tickablesToRemove = new List<ITickable>();

        readonly List<ITickable> _tickables = new List<ITickable>();

        public void Tick()
        {
            ActuallyRemoveTickables();

            TickTickables();

            ActuallyAddTickables();
        }

        public void Add(ITickable tickable)
        {
            if (tickable == null)
            {
                throw new System.ArgumentNullException($"Tried to add {nameof(ITickable)} but it was null at {nameof(TickablesService)}");
            }

            bool contains = _tickables.Contains(tickable);

            if (contains)
            {
                throw new System.Exception($"Tried to add {nameof(ITickable)} but it was already at {nameof(TickablesService)}");
            }

            bool alreadyToAdd = _tickablesToAdd.Contains(tickable);

            if(alreadyToAdd)
            {
                return;
            }

            _tickablesToAdd.Add(tickable);
        }

        public void Remove(ITickable tickable)
        {
            if (tickable == null)
            {
                throw new System.ArgumentNullException($"Tried to remove {nameof(ITickable)} but it was null at {nameof(TickablesService)}");
            }

            bool contained = _tickables.Contains(tickable);

            if (!contained)
            {
                return;
            }

            bool alreadyToRemove = _tickablesToRemove.Contains(tickable);

            if (alreadyToRemove)
            {
                return;
            }

            _tickablesToRemove.Add(tickable);
        }

        public void Clear()
        {
            _tickablesToRemove.AddRange(_tickables);

            ActuallyRemoveTickables();
        }

        void ActuallyAddTickables()
        {
            foreach(ITickable tickable in _tickablesToAdd)
            {
                _tickables.Add(tickable);
            }

            _tickablesToAdd.Clear();
        }

        public void ActuallyRemoveTickables()
        {
            foreach (ITickable tickable in _tickablesToRemove)
            {
                _tickables.Remove(tickable);
            }

            _tickablesToRemove.Clear();
        }

        void TickTickables()
        {
            foreach (ITickable tickable in _tickables)
            {
                tickable.Tick();
            }
        }
    }
}
