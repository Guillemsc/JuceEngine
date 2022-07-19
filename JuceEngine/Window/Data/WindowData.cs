using JuceEngine.Core.Repositories;
using Veldrid;
using Veldrid.Sdl2;

namespace JuceEngine.Window.Data
{
    public sealed class WindowData
    {
        public ISingleRepository<Sdl2Window> WindowRepository { get; } = new SimpleSingleRepository<Sdl2Window>();
        public ISingleRepository<InputSnapshot> CurrentFrameInputSnapshotRepository { get; } = new SimpleSingleRepository<InputSnapshot>();
    }
}
