using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Role: DomainModelBase
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string InternalIdentifier { get; set; }
        public string LandingPageUrl { get; set; }
    }
}
