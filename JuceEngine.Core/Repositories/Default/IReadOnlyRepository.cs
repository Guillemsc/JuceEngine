using System.Collections.Generic;

namespace JuceEngine.Core.Repositories
{
    public interface IReadOnlyRepository<TObject>
    {
        IReadOnlyList<TObject> Items { get; }

        bool Contains(TObject obj);
    }
}
