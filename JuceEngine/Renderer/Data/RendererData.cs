using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.Renderer.Data
{
    public sealed class RendererData
    {
        public ISingleRepository<GraphicsDevice> GraphicsDeviceRepository { get; } = new SimpleSingleRepository<GraphicsDevice>();
        public ISingleRepository<CommandList> CommandListRepository { get; } = new SimpleSingleRepository<CommandList>();
    }
}
