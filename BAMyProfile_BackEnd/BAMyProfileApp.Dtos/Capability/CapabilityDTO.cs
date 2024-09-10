using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Capability;

public class CapabilityDTO
{
    public Guid Id { get; set; }
    public string CapabilityName { get; set; } = null!; //Yetenek Adı

}
