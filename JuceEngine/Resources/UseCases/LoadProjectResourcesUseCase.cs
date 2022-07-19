using JuceEngine.Project.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Resources.UseCases
{
    public sealed class LoadProjectResourcesUseCase
    {
        readonly ProjectData _projectData;
        readonly LoadResourceUseCase _loadResourceUseCase;

        public LoadProjectResourcesUseCase(
            ProjectData projectData,
            LoadResourceUseCase loadResourceUseCase
            )
        {
            _projectData = projectData;
            _loadResourceUseCase = loadResourceUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            bool pathFound = _projectData.PathRepository.TryGet(out string path);

            if (!pathFound)
            {
                return;
            }

            string[] filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach(string filePath in filePaths)
            {
                await _loadResourceUseCase.Execute(filePath, cancellationToken);
            }
        }
    }
}
