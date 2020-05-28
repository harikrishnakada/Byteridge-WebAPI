using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi
{
    public class DomainModelBase
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastChangedDateTime { get; set; }

        public void OnCreated()
        {
            this.CreatedDateTime = DateTime.Now;
            this.LastChangedDateTime = this.CreatedDateTime;
        }  
        public void OnChanged()
        {
            this.LastChangedDateTime = DateTime.Now;
        }
    }
}
