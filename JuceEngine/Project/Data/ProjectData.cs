using JuceEngine.Core.Repositories;

namespace JuceEngine.Project.Data
{
    public sealed class ProjectData
    {
        public ISingleRepository<string> PathRepository { get; } = new SimpleSingleRepository<string>();
    }
}
