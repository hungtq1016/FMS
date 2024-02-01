using AutoMapper;
using Infrastructure.OAuth2.Models.DTOs;
using Infrastructure.OAuth2.Models;

namespace UserService.Infrastructure.Features
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
