using JuceEngine.Core.Repositories;
using System;
using Veldrid;

namespace JuceEngine.InmediateModeUi.UseCases
{
    public sealed class RenderInmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<ImGuiRenderer> _imGuiRendererRepository;

        public RenderInmediateModeUiUseCase(
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
