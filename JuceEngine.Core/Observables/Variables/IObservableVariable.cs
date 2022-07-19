namespace JuceEngine.Core.Observables.Variables
{
    public interface IObservableVariable<T>
    {
        T Value { get; set; }

        event Action<T> OnChange;

        void Clear();
    }
}
