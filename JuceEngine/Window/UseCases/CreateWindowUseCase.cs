using JuceEngine.Core.Repositories;
using JuceEngine.Window.Data;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace JuceEngine.Window.UseCases
{
    public sealed class CreateWindowUseCase
    {
        readonly ISingleRepository<Sdl2Window> _windowRepository;
        readonly WindowResizedUseCase _windowResizedUseCase;

        public CreateWindowUseCase(
            ISingleRepository<Sdl2Window> windowRepository,
            WindowResizedUseCase windowResizedUseCase
            )
        {
            _windowRepository = windowRepository;
            _windowResizedUseCase = windowResizedUseCase;
        }

        public void Execute()
        {
            WindowCreateInfo windowCreateInfo = new WindowCreateInfo()
            {
                X = 100,
                Y = 100,
                WindowWidth = 960,
                WindowHeight = 540,
                WindowTitle = "Veldrid Tutorial"
            };

            SDL_WindowFlags sdlWindowFlags = SDL_WindowFlags.OpenGL | SDL_WindowFlags.Resizable;

            Sdl2Window window = new Sdl2Window(
                windowCreateInfo.WindowTitle,
                windowCreateInfo.X,
                windowCreateInfo.Y,
                windowCreateInfo.WindowWidth,
                windowCreateInfo.WindowHeight,
                sdlWindowFlags,
                threadedProcessing: true
                );

            _windowRepository.Set(window);

            window.Resized += _windowResizedUseCase.Execute;

            _windowResizedUseCase.Execute();
        }
    }
}
