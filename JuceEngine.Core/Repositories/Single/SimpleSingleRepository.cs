using System.Collections.Generic;

namespace JuceEngine.Core.Repositories
{
    public sealed class SimpleSingleRepository<TObject> : ISingleRepository<TObject>
    {
        TObject _item;

        public bool HasItem { get; private set; }

        public void Set(TObject obj)
        {
            _item = obj;
            HasItem = true;
        }

        public void Clear()
        {
            _item = default;
            HasItem = false;
        }

        public bool TryGet(out TObject obj)
        {
            obj = _item;
            return HasItem;
        }

        public bool Contains(TObject obj)
        {
            if (!HasItem)
            {
                return false;
            }

            return EqualityComparer<TObject>.Default.Equals(_item, obj);
        }
    }
}
