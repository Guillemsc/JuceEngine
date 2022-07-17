using System.Collections.Generic;

namespace JuceEngine.Core.Repositories
{
    public interface IRepository<TObject> : IReadOnlyRepository<TObject>
    {
        void Add(TObject obj);
        void Remove(TObject obj);
        void Clear();
    }
}
