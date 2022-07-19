using Veldrid;

namespace JuceEngine.Renderers.TestTriangle.Data
{
    public sealed class TestTriangleData
    {
        public DeviceBuffer VertexBuffer { get; set; }
        public DeviceBuffer IndexBuffer { get; set; }
        public Shader[] Shaders { get; set; }
        public Pipeline Pipeline { get; set; }
    }
}
