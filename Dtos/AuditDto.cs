using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Dtos
{
    public class AuditDto: DomainModelBase
    {
        public int Id { get; set; }
        public DateTime LoggedInDateTime { get; set; }
        public Nullable<DateTime> LoggedOutDateTime { get; set; }
        public int LoggedUserId { get; set; }
        public UserDto LoggedInUser { get; set; }
        public string ClientIp { get; set; }
    }
}
