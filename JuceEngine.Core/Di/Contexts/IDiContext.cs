using JuceEngine.Core.Disposables;

namespace JuceEngine.Core.Di.Contexts
{
    public interface IDiContext<TResult>
    {
        IDisposable<TResult> Install();
    }
}
