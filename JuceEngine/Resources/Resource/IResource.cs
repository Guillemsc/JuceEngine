using System;

namespace JuceEngine.Resources.Resource
{
    public interface IResource
    {
        public Guid Uid { get; }
        public string Name { get; }
    }
}
