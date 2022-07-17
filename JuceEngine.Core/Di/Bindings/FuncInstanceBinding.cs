using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.Bindings
{
    public sealed class FuncInstanceBinding : DiBinding
    {
        readonly Func<IDiResolveContainer, object> _func;

        public FuncInstanceBinding(
            Type identifierType,
            Type actualType,
            Func<IDiResolveContainer, object> func
            )
            : base(identifierType, actualType)
        {
            _func = func;
        }

        protected override object OnBind(IDiResolveContainer container)
        {
            return _func.Invoke(container);
        }
    }
}
