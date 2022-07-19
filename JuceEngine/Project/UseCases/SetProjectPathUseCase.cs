using JuceEngine.Project.Data;
using System.IO;

namespace JuceEngine.Project.UseCases
{
    public sealed class SetProjectPathUseCase
    {
        readonly ProjectData _projectData;

        public SetProjectPathUseCase(
            ProjectData projectData
            )
        {
            _projectData = projectData;
        }

        public void Execute(string path)
        {
            bool exists = Directory.Exists(path);

            if(!exists)
            {
                return;
            }

            _projectData.PathRepository.Set(path);
        }
    }
}
