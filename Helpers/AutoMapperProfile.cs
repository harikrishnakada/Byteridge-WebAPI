using AutoMapper;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            
            CreateMap<Audit, AuditDto>();
            CreateMap<AuditDto, Audit>();
        }
    }
}