using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Audit: DomainModelBase
    {
        public int Id { get; set; }
        public DateTime LoggedInDateTime { get; set; }
        public Nullable<DateTime> LoggedOutDateTime { get; set; }
        public User LoggedInUser { get; set; }
        public int LoggedInUserId { get; set; }
        public string ClientIp { get; set; }
    }
}
