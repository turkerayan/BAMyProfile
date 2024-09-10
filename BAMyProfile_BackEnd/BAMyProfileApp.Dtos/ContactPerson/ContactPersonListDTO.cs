using BAMyProfileApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.ContactPerson
{
    public class ContactPersonListDTO
    {
        public Guid Id { get; set; }
        public string PersonFullName { get; set; } = null!;
      
        public Guid CompanyId { get; set; } 
        public string PersonEmail { get; set; } = null!;
        public string PersonPhoneNumber { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
