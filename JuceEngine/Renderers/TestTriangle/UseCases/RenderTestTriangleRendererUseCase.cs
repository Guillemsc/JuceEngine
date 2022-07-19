using JuceEngine.Core.Repositories;
using JuceEngine.Renderers.TestTriangle.Data;
using Veldrid;

namespace JuceEngine.Renderers.TestTriangle.UseCases
{
    public sealed class RenderTestTriangleRendererUseCase
    {
        readonly TestTriangleData _testTriangleData;

        public RenderTestTriangleRendererUseCase(
            TestTriangleData testTriangleData
            )
        {
            _testTriangleData = testTriangleData;
        }

        public void Execute(GraphicsDevice graphicsDevice, CommandList commandList)
        {
            commandList.SetVertexBuffer(0, _testTriangleData.VertexBuffer);
            commandList.SetIndexBuffer(_testTriangleData.IndexBuffer, IndexFormat.UInt16);
            commandList.SetPipeline(_testTriangleData.Pipeline);
            commandList.DrawIndexed(
                indexCount: 6,
                instanceCount: 1,
                indexStart: 0,
                vertexOffset: 0,
                instanceStart: 0
            );
        }
    }
}
