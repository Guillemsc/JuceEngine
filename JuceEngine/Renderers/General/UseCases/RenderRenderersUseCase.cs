using JuceEngine.Renderers.TestTriangle.UseCases;
using Veldrid;

namespace JuceEngine.Renderers.General.UseCases
{
    public sealed class RenderRenderersUseCase
    {
        readonly RenderTestTriangleRendererUseCase _renderTestTriangleRendererUseCase;

        public RenderRenderersUseCase(
            RenderTestTriangleRendererUseCase renderTestTriangleRendererUseCase
            )
        {
            _renderTestTriangleRendererUseCase = renderTestTriangleRendererUseCase;
        }

        public void Execute(GraphicsDevice graphicsDevice, CommandList commandList)
        {
            _renderTestTriangleRendererUseCase.Execute(graphicsDevice, commandList);
        }
    }
}
