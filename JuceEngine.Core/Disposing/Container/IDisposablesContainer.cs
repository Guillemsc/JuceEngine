using System;

namespace JuceEngine.Core.Disposables.Container
{
    public interface IDisposablesContainer : IDisposable
    {
        void Add(Action dispose);
        void Add(IDisposable disposable);
    }
}
