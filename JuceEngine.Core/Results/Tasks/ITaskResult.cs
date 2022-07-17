namespace JuceEngine.Core.Results.Tasks
{
    /// <summary>
    /// Represents the result of a Task operation.
    /// Instead of returning null when a Task was unsuccessful, we can return a TaskResult
    /// to force the consumer to check for empty/faulty results.
    /// </summary>
    public interface ITaskResult<T>
    {
        bool HasResult { get; }
        bool TryGetResult(out T result);
    }
}
