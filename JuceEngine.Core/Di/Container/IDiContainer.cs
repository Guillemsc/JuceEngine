using System;
using System.Collections.Generic;
using JuceEngine.Core.Di.Bindings;

namespace JuceEngine.Core.Di.Container
{
    public interface IDiContainer : IDiResolveContainer, IDisposable
    {
        public IReadOnlyDictionary<Type, IDiBinding> Bindings { get; }
    }
}
