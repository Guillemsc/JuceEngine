namespace JuceEngine.Core.Repositories
{
    public interface ISingleRepository<TObject> : IReadOnlySingleRepository<TObject>
    {
        void Set(TObject obj);
        void Clear();
    }
}
