using JuceEngine.Core.Repositories;
using JuceEngine.Resources.Resource;
using System;

namespace JuceEngine.Resources.Data
{
    public sealed class ResourcesData
    {
        public IKeyValueRepository<Guid, IResource> ResourcesRepository { get; } = new SimpleKeyValueRepository<Guid, IResource>();
    }
}
