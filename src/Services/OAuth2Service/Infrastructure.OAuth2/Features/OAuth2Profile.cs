using AutoMapper;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;

namespace Infrastructure.OAuth2.Features
{
    public class OAuth2Profile : Profile
    {
        public OAuth2Profile()
        {
            CreateMap<RoleRequest, Role>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Role, RoleResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PermissionRequest, Permission>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Permission, PermissionResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
