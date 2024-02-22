using AutoMapper;
using Core;
using ImageService.Models;
using ImageService.Models.DTOs;
using Infrastructure.EFCore.DTOs;

namespace ImageService.Infrastructure.Features
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageRequest, Image>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Image, ImageResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AbstractFile, Image>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ImageRequest>>, PaginationResponse<List<Image>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Image>>, PaginationResponse<List<ImageResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
