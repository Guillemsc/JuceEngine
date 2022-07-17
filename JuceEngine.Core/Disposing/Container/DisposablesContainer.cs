using System;
using System.Collections.Generic;

namespace JuceEngine.Core.Disposables.Container
{
    public sealed class DisposablesesContainer : IDisposablesContainer
    {
        readonly List<Action> _toDispose = new List<Action>();

        public void Add(Action dispose)
        {
            _toDispose.Add(dispose);
        }

        public void Add(IDisposable disposable)
        {
            _toDispose.Add(disposable.Dispose);
        }

        public void Dispose()
        {
            for (int i = _toDispose.Count - 1; i >= 0; --i)
            {
                _toDispose[i].Invoke();
            }

            _toDispose.Clear();
        }
    }
}
