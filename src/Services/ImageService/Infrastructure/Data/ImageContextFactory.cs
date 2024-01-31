using Infrastructure.EFCore.Data;

namespace ImageService.Infrastructure.Data
{
    public class ImageContextFactory : AppDbContextFactory<ImageContext>
    {
        public ImageContextFactory() : base("imageDB")
        {
        }
    }
}
