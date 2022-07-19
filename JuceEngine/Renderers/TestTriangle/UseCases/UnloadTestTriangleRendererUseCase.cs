using JuceEngine.Renderers.TestTriangle.Data;

namespace JuceEngine.Renderers.TestTriangle.UseCases
{
    public sealed class UnloadTestTriangleRendererUseCase
    {
        readonly TestTriangleData _testTriangleData;

        public UnloadTestTriangleRendererUseCase(
            TestTriangleData testTriangleData
            )
        {
            _testTriangleData = testTriangleData;
        }

        public void Execute()
        {
            _testTriangleData?.Pipeline.Dispose();
            _testTriangleData?.VertexBuffer.Dispose();
            _testTriangleData?.IndexBuffer.Dispose();
        }
    }
}
