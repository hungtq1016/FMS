using AutoMapper;
using Infrastructure.OAuth2.Models.DTOs;
using Infrastructure.OAuth2.Models;
using Infrastructure.EFCore.DTOs;

namespace UserService.Infrastructure.Features
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<UserRequest>>, PaginationResponse<List<User>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<User>>, PaginationResponse<List<UserResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
