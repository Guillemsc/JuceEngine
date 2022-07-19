using JuceEngine.Core.Repositories;
using System;
using Veldrid;

namespace JuceEngine.ImmediateModeUi.UseCases
{
    public sealed class RenderImmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<ImGuiRenderer> _imGuiRendererRepository;

        public RenderImmediateModeUiUseCase(
            IReadOnlySingleRepository<ImGuiRenderer> imGuiRendererRepository
            )
        {
            _imGuiRendererRepository = imGuiRendererRepository;
        }

        public void Execute(GraphicsDevice graphicsDevice, CommandList commandList)
        {
            bool hasImGuiRenderer = _imGuiRendererRepository.TryGet(out ImGuiRenderer renderer);

            if(!hasImGuiRenderer)
            {
                return;
            }

            renderer.Render(graphicsDevice, commandList);
        }
    }
}
