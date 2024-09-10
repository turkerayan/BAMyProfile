using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class CompanyContactInformation : AuditableEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //Navigational Properties:
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
