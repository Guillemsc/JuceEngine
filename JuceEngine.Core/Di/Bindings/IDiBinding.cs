using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.Bindings
{
    public interface IDiBinding
    {
        Type IdentifierType { get; }
        Type ActualType { get; }
        object Value { get; }
        bool Lazy { get; }

        void Bind(IDiResolveContainer container);
        void Init(IDiResolveContainer container);
        void Dispose(IDiResolveContainer container);
    }
}
