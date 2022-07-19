using JuceEngine.Core.Maths.Data;
using JuceEngine.Renderer.Renderables;
using JuceEngine.Renderers.TestTriangle.Contants;
using JuceEngine.Renderers.TestTriangle.Data;
using System;
using System.Numerics;
using System.Text;
using Veldrid;
using Veldrid.SPIRV;

namespace JuceEngine.Renderers.TestTriangle.Renderables
{
    public sealed class TestTriangleRenderable : IRenderable
    {
        DeviceBuffer _vertexBuffer;
        DeviceBuffer _indexBuffer;
        Shader[] _shaders;
        Pipeline _pipeline;

        public void Load(GraphicsDevice graphicsDevice, Framebuffer framebuffer)
        {
            ResourceFactory factory = graphicsDevice.ResourceFactory;

            VertexPositionColor[] quadVertices =
            {
                new VertexPositionColor(new Vector2(-0.75f, -0.75f), RgbaFloat.Blue),
                new VertexPositionColor(new Vector2(0.75f, -0.75f), RgbaFloat.Yellow),
                new VertexPositionColor(new Vector2(0.75f, 0.75f), RgbaFloat.Green),
                new VertexPositionColor(new Vector2(-0.75f, 0.75f), RgbaFloat.Red),
            };

            ushort[] quadIndices = { 0, 1, 2, 0, 2, 3 };

            _vertexBuffer = factory.CreateBuffer(new BufferDescription(
                4 * VertexPositionColor.SizeInBytes,
                BufferUsage.VertexBuffer
            ));

            _indexBuffer = factory.CreateBuffer(new BufferDescription(
                6 * sizeof(ushort),
                BufferUsage.IndexBuffer
            ));

            graphicsDevice.UpdateBuffer(_vertexBuffer, 0, quadVertices);
            graphicsDevice.UpdateBuffer(_indexBuffer, 0, quadIndices);

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

            _shaders = factory.CreateFromSpirv(
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
                shaders: _shaders
            );
            pipelineDescription.Outputs = graphicsDevice.SwapchainFramebuffer.OutputDescription;

            _pipeline = factory.CreateGraphicsPipeline(pipelineDescription);
        }

        public void Render(CommandList commandList)
        {
            commandList.SetVertexBuffer(0, _vertexBuffer);
            commandList.SetIndexBuffer(_indexBuffer, IndexFormat.UInt16);
            commandList.SetPipeline(_pipeline);
            commandList.DrawIndexed(
                indexCount: 6,
                instanceCount: 1,
                indexStart: 0,
                vertexOffset: 0,
                instanceStart: 0
            );
        }

        public void Resized(Int2 size)
        {
            
        }

        public void Dispose()
        {
            _pipeline.Dispose();
            _vertexBuffer.Dispose();
            _indexBuffer.Dispose();
        }
    }
}
