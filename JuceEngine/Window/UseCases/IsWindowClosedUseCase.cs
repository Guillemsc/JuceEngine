using JuceEngine.Core.Repositories;
using Veldrid.Sdl2;

namespace JuceEngine.Window.UseCases
{
    public sealed class IsWindowClosedUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;

        public IsWindowClosedUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository
            )
        {
            _windowRepository = windowRepository;
        }

        public bool Execute()
        {

            bool found = _windowRepository.TryGet(out Sdl2Window window);

            if (!found)
            {
                return false;
            }

            return !window.Exists;
        }
    }
}
