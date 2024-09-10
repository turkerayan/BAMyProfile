using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class ContactPerson : AuditableEntity
    {
        public string PersonFullName { get; set; }
       
        public Guid CompanyId { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

        //Nav Property

        public virtual Company Company { get; set; }

    }
}
