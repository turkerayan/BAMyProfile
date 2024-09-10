using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    
    public class Reference : AuditableEntity
    {  
        public string Name { get; set; }     
        public string Company { get; set; }   
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }

        // Navigation property  many-to-many ilişkisi 
        public virtual ICollection<ReferenceStudent> Students { get; set; }
    }
}
