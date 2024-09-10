using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Capability : AuditableEntity
{
    public string CapabilityName { get; set; } = null!; //Yetenek Adı
    public virtual IEnumerable<CapabilityStudent>? CapabilityStudents { get; set; }

}
