using JuceEngine.Core.Repositories;
using Veldrid;
using Veldrid.Sdl2;

namespace JuceEngine.Window.UseCases
{
    public sealed class PumpWindowEventsUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;
        readonly ISingleRepository<InputSnapshot> _currentFrameInputSnapshotRepository;

        public PumpWindowEventsUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository,
            ISingleRepository<InputSnapshot> currentFrameInputSnapshotRepository
            )
        {
            _windowRepository = windowRepository;
            _currentFrameInputSnapshotRepository = currentFrameInputSnapshotRepository;
        }

        public void Execute()
        {
            bool found = _windowRepository.TryGet(out Sdl2Window window);

            if(!found)
            {
                return;
            }

            if(!window.Exists)
            {
                return;
            }

            InputSnapshot inputSnapshot = window.PumpEvents();

            _currentFrameInputSnapshotRepository.Set(inputSnapshot);
        }
    }
}
