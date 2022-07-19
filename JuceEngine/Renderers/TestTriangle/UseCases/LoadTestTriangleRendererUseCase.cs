using JuceEngine.Core.Repositories;
using JuceEngine.Renderers.TestTriangle.Contants;
using JuceEngine.Renderers.TestTriangle.Data;
using System;
using System.Numerics;
using System.Text;
using Veldrid;
using Veldrid.SPIRV;

namespace JuceEngine.Renderers.TestTriangle.UseCases
{
    public sealed class LoadTestTriangleRendererUseCase
    {
        readonly TestTriangleData _testTriangleData;
        readonly IReadOnlySingleRepository<GraphicsDevice> _graphicsDeviceRepository;

        public LoadTestTriangleRendererUseCase(
            TestTriangleData testTriangleData,
            IReadOnlySingleRepository<GraphicsDevice> graphicsDeviceRepository
            )
        {
            _testTriangleData = testTriangleData;
            _graphicsDeviceRepository = graphicsDeviceRepository;
        }

        public void Execute()
        {
            bool graphicsDeviceFound = _graphicsDeviceRepository.TryGet(out GraphicsDevice graphicsDevice);

            if (!graphicsDeviceFound)
            {
                return;
            }

            ResourceFactory factory = graphicsDevice.ResourceFactory;

            VertexPositionColor[] quadVertices =
            {
                new VertexPositionColor(new Vector2(-0.75f, -0.75f), RgbaFloat.Blue),
                new VertexPositionColor(new Vector2(0.75f, -0.75f), RgbaFloat.Yellow),
                new VertexPositionColor(new Vector2(0.75f, 0.75f), RgbaFloat.Green),
                new VertexPositionColor(new Vector2(-0.75f, 0.75f), RgbaFloat.Red),
            };

            ushort[] quadIndices = { 0, 1, 2, 0, 2, 3 };

            _testTriangleData.VertexBuffer = factory.CreateBuffer(new BufferDescription(
                4 * VertexPositionColor.SizeInBytes, 
                BufferUsage.VertexBuffer
            ));

            _testTriangleData.IndexBuffer = factory.CreateBuffer(new BufferDescription(
                6 * sizeof(ushort), 
                BufferUsage.IndexBuffer
            ));

            graphicsDevice.UpdateBuffer(_testTriangleData.VertexBuffer, 0, quadVertices);
            graphicsDevice.UpdateBuffer(_testTriangleData.IndexBuffer, 0, quadIndices);

            VertexLayoutDescription vertexLayout = new VertexLayoutDescription(
                new VertexElementDescription(
                    "Position", 
                    VertexElementSemantic.TextureCoordinate, 
                    VertexElementFormat.Float2
                ),
                new VertexElementDescription(
                    "Color", 
                    VertexElementSemantic.TextureCoordinate, 
                    VertexElementFormat.Float4
                    )
                );

            ShaderDescription vertexShaderDescription = new ShaderDescription(
                ShaderStages.Vertex,
                Encoding.UTF8.GetBytes(ShadersConstants.VertexCode),
                "main"
             );

            ShaderDescription fragmentShaderDescription = new ShaderDescription(
                ShaderStages.Fragment,
                Encoding.UTF8.GetBytes(ShadersConstants.FragmentCode),
                "main"
            );

            _testTriangleData.Shaders = factory.CreateFromSpirv(
                vertexShaderDescription, 
                fragmentShaderDescription
            );

            GraphicsPipelineDescription pipelineDescription = new GraphicsPipelineDescription();
            pipelineDescription.BlendState = BlendStateDescription.SingleOverrideBlend;
            pipelineDescription.DepthStencilState = new DepthStencilStateDescription(
                depthTestEnabled: true,
                depthWriteEnabled: true,
                comparisonKind: ComparisonKind.LessEqual
            );
            pipelineDescription.RasterizerState = new RasterizerStateDescription(
                cullMode: FaceCullMode.Back,
                fillMode: PolygonFillMode.Solid,
                frontFace: FrontFace.CounterClockwise,
                depthClipEnabled: true,
                scissorTestEnabled: false
            );
            pipelineDescription.PrimitiveTopology = PrimitiveTopology.TriangleList;
            pipelineDescription.ResourceLayouts = Array.Empty<ResourceLayout>();
            pipelineDescription.ShaderSet = new ShaderSetDescription(
                vertexLayouts: new VertexLayoutDescription[] { vertexLayout },
                shaders: _testTriangleData.Shaders
            );
            pipelineDescription.Outputs = graphicsDevice.SwapchainFramebuffer.OutputDescription;

            _testTriangleData.Pipeline = factory.CreateGraphicsPipeline(pipelineDescription);
        }
    }
}
