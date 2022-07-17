using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.Renderer.Data
{
    public sealed class RendererData
    {
        public ISingleRepository<CommandList> CommandListRepository { get; } = new SimpleSingleRepository<CommandList>();
    }
}
