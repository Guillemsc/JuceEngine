using System;

namespace JuceEngine.Resources.Meta
{
    public sealed class SimpleMeta : IMeta
    {
        public Guid Uid { get; }

        public SimpleMeta(Guid uid)
        {
            Uid = uid;
        }
    }
}
