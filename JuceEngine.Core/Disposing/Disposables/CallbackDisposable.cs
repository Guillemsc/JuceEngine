using System;

namespace JuceEngine.Core.Disposables
{
    public sealed class CallbackDisposable<T> : IDisposable<T>
    {
        readonly Action<T> _onDispose;

        bool _disposed;

        public T Value { get; }

        public CallbackDisposable(T value, Action<T> onDispose)
        {
            Value = value;
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            _onDispose?.Invoke(Value);
        }
    }
}
