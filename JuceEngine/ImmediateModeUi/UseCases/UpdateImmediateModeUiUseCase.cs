using JuceEngine.Core.Repositories;
using JuceEngine.Editor.General.UseCases;
using System;
using Veldrid;

namespace JuceEngine.ImmediateModeUi.UseCases
{
    public sealed class UpdateImmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<InputSnapshot> _currentFrameInputSnapshotRepository;
        readonly IReadOnlySingleRepository<ImGuiRenderer> _imGuiRendererRepository;
        readonly DrawEditorUseCase _drawEditorUseCase;

        public UpdateImmediateModeUiUseCase(
            IReadOnlySingleRepository<InputSnapshot> currentFrameInputSnapshotRepository,
            IReadOnlySingleRepository<ImGuiRenderer> imGuiRendererRepository,
            DrawEditorUseCase drawEditorUseCase
            )
        {
            _currentFrameInputSnapshotRepository = currentFrameInputSnapshotRepository;
            _imGuiRendererRepository = imGuiRendererRepository;
            _drawEditorUseCase = drawEditorUseCase;
        }

        public void Execute()
        {
            bool inputSnapshotFound = _currentFrameInputSnapshotRepository.TryGet(out InputSnapshot inputSnapshot);
           
            if(!inputSnapshotFound)
            {
                return;
            }

            bool imGuiRendererFound = _imGuiRendererRepository.TryGet(out ImGuiRenderer renderer);

            if (!imGuiRendererFound)
            {
                return;
            }

            renderer.Update(1f / 60f, inputSnapshot);

            _drawEditorUseCase.Execute();
        }
    }
}
