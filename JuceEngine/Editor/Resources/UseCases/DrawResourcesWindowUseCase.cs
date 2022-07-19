using ImGuiNET;
using JuceEngine.Core.Repositories;
using JuceEngine.Resources.Data;
using JuceEngine.Resources.Resource;
using System;

namespace JuceEngine.Editor.Resources.UseCases
{
    public sealed class DrawResourcesWindowUseCase
    {
        readonly IReadOnlyKeyValueRepository<Guid, IResource> _resourcesRepository;

        public DrawResourcesWindowUseCase(
            IReadOnlyKeyValueRepository<Guid, IResource> resourcesRepository
            )
        {
            _resourcesRepository = resourcesRepository;
        }

        public void Execute()
        {
            if (ImGui.Begin("Resources"))
            {
                foreach(IResource resource in _resourcesRepository.Items)
                {
                    string resourceText = $"- {resource.Name} - {resource.Uid}";

                    ImGui.Text(resourceText);
                }
            }
            ImGui.End();
        }
    }
}
