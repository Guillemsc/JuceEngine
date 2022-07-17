namespace JuceEngine.Core.Di.Container
{
    public interface IDiResolveContainer
    {
        T Resolve<T>();
    }
}
