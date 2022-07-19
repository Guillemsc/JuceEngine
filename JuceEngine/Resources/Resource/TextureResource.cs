using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace JuceEngine.Resources.Resource
{
    public sealed class TextureResource : IResource
    {
        public Guid Uid { get; }
        public string Name { get; }
        public Image<Rgba32> ImageSharpTexture { get; }

        public TextureResource(
            Guid uid,
            string name,
            Image<Rgba32> imageSharpTexture
            )
        {
            Uid = uid;
            Name = name;
            ImageSharpTexture = imageSharpTexture;
        }
    }
}
