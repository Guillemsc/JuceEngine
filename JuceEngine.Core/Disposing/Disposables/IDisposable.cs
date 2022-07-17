using System;

namespace JuceEngine.Core.Disposables
{
    public interface IDisposable<T> : IDisposable
    {
        public T Value { get; }
    }
}
