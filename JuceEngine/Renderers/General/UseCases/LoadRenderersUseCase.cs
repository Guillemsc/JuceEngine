using JuceEngine.Renderers.TestTriangle.UseCases;

namespace JuceEngine.Renderers.General.UseCases
{
    public sealed class LoadRenderersUseCase
    {
        readonly LoadTestTriangleRendererUseCase _loadTestTriangleRendererUseCase;

        public LoadRenderersUseCase(LoadTestTriangleRendererUseCase loadTestTriangleRendererUseCase)
        {
            _loadTestTriangleRendererUseCase = loadTestTriangleRendererUseCase;
        }

        public void Execute()
        {
            _loadTestTriangleRendererUseCase.Execute();
        }
    }
}
