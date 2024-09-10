using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Core.Entities.Interfaces;
using BAMyProfileApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class CapabilityStudent : AuditableEntity
{
    public Guid CapabilityId { get; set; }
    public virtual Capability ? Capability { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; }

}
