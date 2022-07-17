using JuceEngine.Core.Repositories;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace JuceEngine.Window.UseCases
{
    public sealed class CreateWindowUseCase
    {
        readonly ISingleRepository<Sdl2Window> _windowRepository;

        public CreateWindowUseCase(
            ISingleRepository<Sdl2Window> windowRepository
            )
        {
            _windowRepository = windowRepository;
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

            Sdl2Window window = VeldridStartup.CreateWindow(windowCreateInfo);
        }
    }
}
