using JuceEngine.Core.Di.Container;
using System;
using System.Collections.Generic;
using JuceEngine.Core.Di.BindingActions;

namespace JuceEngine.Core.Di.Bindings
{
    public abstract class DiBinding : IDiBinding
    {
        readonly List<IDiBindingAction> _initActions = new List<IDiBindingAction>();
        readonly List<IDiBindingAction> _disposeActions = new List<IDiBindingAction>();

        bool _binded;

        public Type IdentifierType { get; }
        public Type ActualType { get; }
        public object Value { get; private set; }
        public bool Lazy { get; private set; } = true;

        protected DiBinding(Type identifierType, Type actualType)
        {
            IdentifierType = identifierType;
            ActualType = actualType;
        }

        public void NonLazy()
        {
            Lazy = false;
        }

        public void AddInitAction(IDiBindingAction initAction)
        {
            if (_binded)
            {
                return;
            }

            _initActions.Add(initAction);
        }

        public void AddDisposeAction(IDiBindingAction disposeAction)
        {
            if (_binded)
            {
                return;
            }

            _disposeActions.Add(disposeAction);
        }

        public void Bind(IDiResolveContainer container)
        {
            if(_binded)
            {
                return;
            }

            _binded = true;

            Value = OnBind(container);
        }

        public void Init(IDiResolveContainer container)
        {
            if (!_binded)
            {
                return;
            }

            if (Value == null)
            {
                return;
            }

            foreach (IDiBindingAction initAction in _initActions)
            {
                initAction.Execute(container, Value);
            }

            _initActions.Clear();
        }

        public void Dispose(IDiResolveContainer container)
        {
            if (!_binded)
            {
                return;
            }

            if (Value == null)
            {
                return;
            }

            foreach (IDiBindingAction disposeAction in _disposeActions)
            {
                disposeAction.Execute(container, Value);
            }

            _disposeActions.Clear();
        }

        protected abstract object OnBind(IDiResolveContainer container);
    }
}
