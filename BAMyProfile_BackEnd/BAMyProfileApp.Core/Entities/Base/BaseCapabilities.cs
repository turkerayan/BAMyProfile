using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMyProfileApp.Core.Enums;

namespace BAMyProfileApp.Core.Entities.Base;

public class BaseCapabilities : AuditableEntity
{
    public string CapabilityName { get; set; } = null!; //Yetenek Adı
}
