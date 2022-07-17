using JuceEngine.Core.Di.Bindings;
using JuceEngine.Core.Di.Container;
using System;

namespace JuceEngine.Core.Di.Builder
{
    public sealed class DiBindingBuilder<T> : IDiBindingBuilder<T>
    {
        readonly DiContainerBuilder _containerBuilder;
        readonly Type _identifierType;

        public DiBindingBuilder(
            DiContainerBuilder containerBuilder,
            Type identifierType
            )
        {
            _containerBuilder = containerBuilder;
            _identifierType = identifierType;
        }

        public IDiBindingActionBuilder<T> FromNew()
        {
            Type type = typeof(T);

            bool canBeCreated = type.GetConstructor(Type.EmptyTypes) != null && !type.IsAbstract;

            if(!canBeCreated)
            {
                throw new Exception($"Object of type {type.Name} cannot be instantiated on runtime");
            }

            DiBinding binding = new NewInstanceBinding(_identifierType, type);

            return AddBinding(binding);
        }

        public IDiBindingActionBuilder<T> FromInstance(T instance)
        {
            Type type = typeof(T);

            DiBinding binding = new ReferenceInstanceBinding(_identifierType, type, instance);

            return AddBinding(binding);
        }

        public IDiBindingActionBuilder<T> FromFunction(Func<IDiResolveContainer, T> func)
        {
            Type type = typeof(T);

            Func<IDiResolveContainer, object> castedFunc = (IDiResolveContainer c) => func.Invoke(c);

            DiBinding binding = new FuncInstanceBinding(_identifierType, type, castedFunc);

            return AddBinding(binding);
        }

        public IDiBindingActionBuilder<T> FromContainer(IDiContainer container)
        {
            return FromFunction((c) => container.Resolve<T>());
        }

        private DiBindingActionBuilder<T> AddBinding(DiBinding binding)
        {
            _containerBuilder.AddBinding(binding);

            return new DiBindingActionBuilder<T>(binding);
        }
    }
}
