using JuceEngine.Core.Di.Bindings;
using System;
using System.Collections.Generic;

namespace JuceEngine.Core.Di.Container
{
    public sealed class DiContainer : IDiContainer
    {
        readonly List<Type> _resolvingStack = new List<Type>();

        readonly Dictionary<Type, IDiBinding> _bindings;

        public IReadOnlyDictionary<Type, IDiBinding> Bindings => _bindings;

        public DiContainer(Dictionary<Type, IDiBinding> bindings)
        {
            _bindings = bindings;

            BindNonLazy();
        }

        private void BindNonLazy()
        {
            foreach(KeyValuePair<Type, IDiBinding> binding in _bindings)
            {
                if(binding.Value.Lazy)
                {
                    continue;
                }

                Bind(binding.Value);
            }
        }

        private void Bind(IDiBinding binding)
        {
            _resolvingStack.Add(binding.IdentifierType);

            binding.Bind(this);

            if (binding.Value == null)
            {
                throw new Exception($"Object of type {binding.IdentifierType.Name} Binding returned a null object");
            }

            _resolvingStack.Remove(binding.IdentifierType);

            binding.Init(this);
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);

            bool isCircularDependence = _resolvingStack.Contains(type);

            if (isCircularDependence)
            {
                throw new Exception($"Circular dependence found resolving {type.Name}");
            }

            bool found = _bindings.TryGetValue(type, out IDiBinding binding);

            if(!found)
            {
                throw new Exception($"Object of type {type.Name} could not be resolved");
            }

            Bind(binding);

            return (T)binding.Value;
        }

        public void Dispose()
        {
            _resolvingStack.Clear();

            foreach (KeyValuePair<Type, IDiBinding> binding in _bindings)
            {
                binding.Value.Dispose(this);
            }

            _bindings.Clear();
        }
    }
}
