using JuceEngine.Render.UseCases;
using JuceEngine.Window.UseCases;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.General.UseCases
{
    public sealed class LoadUseCase
    {
        readonly CreateWindowUseCase _createWindowUseCase;
        readonly CreateGraphicsDeviceUseCase _createGraphicsDeviceUseCase;

        public LoadUseCase(
            CreateWindowUseCase createWindowUseCase,
            CreateGraphicsDeviceUseCase createGraphicsDeviceUseCase
            )
        {
            _createWindowUseCase = createWindowUseCase;
            _createGraphicsDeviceUseCase = createGraphicsDeviceUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            _createWindowUseCase.Execute();
            _createGraphicsDeviceUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}
