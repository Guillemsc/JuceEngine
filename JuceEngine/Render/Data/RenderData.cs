using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.Render.Data
{
    public sealed class RenderData
    {
        public ISingleRepository<GraphicsDevice> GraphicsDeviceRepository { get; } 
            = new SimpleSingleRepository<GraphicsDevice>();
    }
}
