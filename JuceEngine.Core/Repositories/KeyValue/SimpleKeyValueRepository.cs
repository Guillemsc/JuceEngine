using System.Collections.Generic;
using System.Linq;

namespace JuceEngine.Core.Repositories
{
    public sealed class SimpleKeyValueRepository<TId, TObject> : IKeyValueRepository<TId, TObject> 
    {
        readonly Dictionary<TId, TObject> _items = new Dictionary<TId, TObject>();

        public IReadOnlyList<TObject> Items => _items.Values.ToList();

        public void Add(TId id, TObject obj)
        {
            _items.Add(id, obj);
        }

        public void Remove(TId id)
        {
            _items.Remove(id);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool TryGet(TId id, out TObject obj)
        {
            return _items.TryGetValue(id, out obj);
        }
    }
}
