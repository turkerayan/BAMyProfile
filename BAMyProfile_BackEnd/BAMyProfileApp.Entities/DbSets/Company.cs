using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class Company : AuditableEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Sector { get; set; }
        public string GeneralInformation { get; set; }


        // Navigational Properties:
        public virtual ICollection<CompanyContactInformation> CompanyContactInformations { get; set; }
		public virtual ICollection<ApplicationInterview>? ApplicationInterviews { get; set; }
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
