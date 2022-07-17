using System.Threading.Tasks;

namespace JuceEngine.Core.Disposables
{
    public interface ITaskDisposable<T>
    {
        public T Value { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        Task Dispose();
    }
}
