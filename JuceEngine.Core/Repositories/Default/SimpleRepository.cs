using System.Collections.Generic;

namespace JuceEngine.Core.Repositories
{
    public sealed class SimpleRepository<TObject> : IRepository<TObject>
    {
        readonly List<TObject> _items = new List<TObject>();

        public IReadOnlyList<TObject> Items => _items;

        public void Add(TObject obj)
        {
            _items.Add(obj);
        }

        public void Remove(TObject obj)
        {
            _items.Remove(obj);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(TObject obj)
        {
            return _items.Contains(obj);
        }
    }
}
