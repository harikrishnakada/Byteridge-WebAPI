using AutoMapper;
using WebApi.Dtos;
using WebApi.Model;

namespace WebApi.Data
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