using JuceEngine.Core.Maths.Data;
using JuceEngine.Core.Repositories;
using JuceEngine.Window.Data;
using Veldrid;
using Veldrid.Sdl2;

namespace JuceEngine.Window.UseCases
{
    public sealed class WindowResizedUseCase
    {
        readonly IReadOnlySingleRepository<Sdl2Window> _windowRepository;
        readonly WindowSizeData _windowSizeData;

        public WindowResizedUseCase(
            IReadOnlySingleRepository<Sdl2Window> windowRepository,
            WindowSizeData windowSizeData
            )
        {
            _windowRepository = windowRepository;
            _windowSizeData = windowSizeData;
        }

        public void Execute()
        {
            bool windowFound = _windowRepository.TryGet(out Sdl2Window window);

            if(!windowFound)
            {
                return;
            }

            _windowSizeData.Size = new Int2(window.Width, window.Height);
        }
    }
}
