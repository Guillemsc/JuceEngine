using JuceEngine.Core.Repositories;
using Veldrid.Sdl2;

namespace JuceEngine.Window.UseCases
{
    public sealed class PumpWindowEventsUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;

        public PumpWindowEventsUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository
            )
        {
            _windowRepository = windowRepository;
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

            window.PumpEvents();
        }
    }
}
