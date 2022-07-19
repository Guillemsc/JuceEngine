using JuceEngine.Project.Data;
using System.IO;

namespace JuceEngine.Project.UseCases
{
    public sealed class GetFullPathFromLocalProjectPathUseCase
    {
        readonly ProjectData _projectData;

        public GetFullPathFromLocalProjectPathUseCase(
            ProjectData projectData
            )
        {
            _projectData = projectData;
        }

        public string Execute(string localPath)
        {
            bool pathFound = _projectData.PathRepository.TryGet(out string path);

            if(!pathFound)
            {
                return string.Empty;
            }

            return Path.Combine(path, localPath);
        }
    }
}
