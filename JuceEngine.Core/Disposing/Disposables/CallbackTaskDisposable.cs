namespace JuceEngine.Core.Disposables
{
    public sealed class TaskDisposable<T> : ITaskDisposable<T>
    {
        readonly Func<T, Task> _onDispose;

        public T Value { get; }

        public TaskDisposable(T value, Func<T, Task> onDispose)
        {
            Value = value;
            _onDispose = onDispose;
        }

        public Task Dispose()
        {
            return _onDispose.Invoke(Value);
        }
    }
}
