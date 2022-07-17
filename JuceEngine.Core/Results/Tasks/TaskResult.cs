namespace JuceEngine.Core.Results.Tasks
{
    public sealed class TaskResult<T> : ITaskResult<T>
    {
        readonly T _value;

        public bool HasResult { get; }

        TaskResult(bool hasResult, T value)
        {
            HasResult = hasResult;
            _value = value;
        }

        public static ITaskResult<T> FromResult(T value)
        {
            return new TaskResult<T>(true, value);
        }

        public static ITaskResult<T> FromEmpty()
        {
            return new TaskResult<T>(false, default);
        }

        public bool TryGetResult(out T result)
        {
            result = _value;
            return HasResult;
        }
    }
}
