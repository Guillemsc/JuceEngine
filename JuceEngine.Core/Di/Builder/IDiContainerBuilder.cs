using System;
using System.Collections.Generic;
using JuceEngine.Core.Di.Container;
using JuceEngine.Core.Di.Installers;

namespace JuceEngine.Core.Di.Builder
{
    public interface IDiContainerBuilder
    {
        IDiBindingBuilder<T> Bind<T>();
        IDiBindingBuilder<TConcrete> Bind<TInterface, TConcrete>();
        void Bind(params IDiContainer[] containers);
        void Bind(IReadOnlyList<IDiContainer> container);
        void Bind(params IInstaller[] installers);
        void Bind(IReadOnlyList<IInstaller> container);
        void Bind(Action<IDiContainerBuilder> action);

        IDiContainer Build();
    }
}
