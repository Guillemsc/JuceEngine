using JuceEngine.Core.Repositories;
using JuceEngine.Resources.Resource;
using System;

namespace JuceEngine.Resources.UseCases
{
    public sealed class AddResourceUseCase
    {
        readonly IKeyValueRepository<Guid, IResource> _resourcesRepository;

        public AddResourceUseCase(
            IKeyValueRepository<Guid, IResource> resourcesRepository
            )
        {
            _resourcesRepository = resourcesRepository;
        }

        public void Execute(IResource resource)
        {
            _resourcesRepository.Add(resource.Uid, resource);
        }
    }
}
