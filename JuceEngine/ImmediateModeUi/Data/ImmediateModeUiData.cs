using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.ImmediateModeUi.Data
{
    public sealed class ImmediateModeUiData
    {
        public ISingleRepository<ImGuiRenderer> ImmediateModeUiRendererRepository { get; }
            = new SimpleSingleRepository<ImGuiRenderer>();
    }
}
