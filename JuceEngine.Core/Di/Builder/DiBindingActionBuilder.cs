using JuceEngine.Core.Di.BindingActions;
using JuceEngine.Core.Di.Bindings;
using JuceEngine.Core.Di.Container;

namespace JuceEngine.Core.Di.Builder
{
    public sealed class DiBindingActionBuilder<T> : IDiBindingActionBuilder<T>
    {
        readonly DiBinding _binding;

        public DiBindingActionBuilder(DiBinding binding)
        {
            this._binding = binding;
        }

        public Type IdentifierType => _binding.IdentifierType;
        public Type ActualType => _binding.ActualType;

        public IDiBindingActionBuilder<T> NonLazy()
        {
            _binding.NonLazy();

            return this;
        }

        public IDiBindingActionBuilder<T> WhenInit(Action<IDiResolveContainer, T> action)
        {
            void CastedAction(IDiResolveContainer resolver, object obj) => action.Invoke(resolver, (T)obj);

            IDiBindingAction bindingAction = new ActionWithContainerBindingAction(CastedAction);

            _binding.AddInitAction(bindingAction);

            return this;
        }

        public IDiBindingActionBuilder<T> WhenInit(Func<T, Action> func)
        {
            void CastedAction(object obj)
            {
                Action returnedAction = func.Invoke((T)obj);

                returnedAction.Invoke();
            }

            IDiBindingAction bindingAction = new ActionWithoutContainerBindingAction(CastedAction);

            _binding.AddInitAction(bindingAction);

            return this;
        }

        public IDiBindingActionBuilder<T> WhenDispose(Action<IDiResolveContainer, T> action)
        {
            void CastedAction(IDiResolveContainer resolver, object obj) => action.Invoke(resolver, (T)obj);

            IDiBindingAction bindingAction = new ActionWithContainerBindingAction(CastedAction);

            _binding.AddDisposeAction(bindingAction);

            return this;
        }

        public IDiBindingActionBuilder<T> WhenDispose(Action<T> action)
        {
            void CastedAction(object obj) => action.Invoke((T)obj);

            IDiBindingAction bindingAction = new ActionWithoutContainerBindingAction(CastedAction);

            _binding.AddDisposeAction(bindingAction);

            return this;
        }

        public IDiBindingActionBuilder<T> WhenDispose(Func<T, Action> func)
        {
            void CastedAction(object obj)
            {
                Action returnedAction = func.Invoke((T)obj);

                returnedAction.Invoke();
            }

            IDiBindingAction bindingAction = new ActionWithoutContainerBindingAction(CastedAction);

            _binding.AddDisposeAction(bindingAction);

            return this;
        }

        public IDiBindingActionBuilder<T> WhenDispose(IDisposable disposable)
        {
            IDiBindingAction bindingAction = new EmptyActionWithouthContainerBindingAction(disposable.Dispose);
            _binding.AddDisposeAction(bindingAction);

            return this;
        }
    }
}
