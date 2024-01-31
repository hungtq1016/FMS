using Core;
using ImageService.Infrastructure.Data;
using ImageService.Models;
using Infrastructure.EFCore.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace ImageService.Infrastructure
{
    public class ImageRepository : RepositoryBase<ImageContext, Image>  
    {
        public ImageRepository(ImageContext context, IMemoryCache cache) : base(context, cache)
        {
        }
    }
}
