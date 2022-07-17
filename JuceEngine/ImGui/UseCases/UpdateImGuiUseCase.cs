using JuceEngine.Core.Repositories;
using System;
using Veldrid;

namespace JuceEngine.InmediateModeUi.UseCases
{
    public sealed class UpdateInmediateModeUiUseCase
    {
        readonly IReadOnlySingleRepository<InputSnapshot> _currentFrameInputSnapshotRepository;
        readonly IReadOnlySingleRepository<ImGuiRenderer> _imGuiRendererRepository;

        public UpdateInmediateModeUiUseCase(
            IReadOnlySingleRepository<InputSnapshot> currentFrameInputSnapshotRepository,
            IReadOnlySingleRepository<ImGuiRenderer> imGuiRendererRepository
            )
        {
            _currentFrameInputSnapshotRepository = currentFrameInputSnapshotRepository;
            _imGuiRendererRepository = imGuiRendererRepository;
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
        }
    }
}
