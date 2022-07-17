using JuceEngine.Core.Repositories;
using Veldrid;

namespace JuceEngine.InmediateModeUi.Data
{
    public sealed class InmediateModeUiData
    {
        public ISingleRepository<ImGuiRenderer> InmediateModeUiRendererRepository { get; }
            = new SimpleSingleRepository<ImGuiRenderer>();
    }
}
