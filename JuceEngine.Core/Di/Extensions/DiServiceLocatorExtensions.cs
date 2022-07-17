using JuceEngine.Core.Di.Builder;
using JuceEngine.Core.Di.Container;
using JuceEngine.Core.Service;

namespace JuceEngine.Core.Di.Extensions
{
    public static class DiServiceLocatorExtensions
    {
        public static IDiBindingActionBuilder<T> LinkToServiceLocator<T>(this IDiBindingActionBuilder<T> builder)
        {
            builder.WhenInit((c, o) => ServiceLocator.Register(builder.IdentifierType, o));
            builder.WhenDispose((c, o) => ServiceLocator.Unregister(builder.IdentifierType));

            builder.NonLazy();

            return builder;
        }

        public static IDiBindingActionBuilder<T> FromServiceLocator<T>(this IDiBindingBuilder<T> builder)
        {
            T Function(IDiResolveContainer resolver)
            {
                return ServiceLocator.Get<T>();
            }

            return builder.FromFunction(Function).NonLazy();
        }
    }
}
