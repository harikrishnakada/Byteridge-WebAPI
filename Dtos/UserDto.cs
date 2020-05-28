using WebApi.Model;

namespace WebApi.Dtos
{
    public class UserDto: DomainModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}