using JuceEngine.Core.Maths.Data;
using System;
using Veldrid;

namespace JuceEngine.Renderer.Renderables
{
    public interface IRenderable : IDisposable
    {
        void Load(GraphicsDevice graphicsDevice, Framebuffer framebuffer);
        void Resized(Int2 size);
        void Render(CommandList commandList);
    }
}
