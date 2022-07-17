using System.Collections.Generic;

namespace JuceEngine.Core.Repositories
{
    public interface IReadOnlyKeyValueRepository<TId, TObject>
    {
        IReadOnlyList<TObject> Items { get; }

        bool TryGet(TId id, out TObject obj);
    }
}
