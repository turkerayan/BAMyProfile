using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.CapabilityStudent;

public class CapabilityStudentCreateDTO
{
    public Guid CapabilityId { get; set; }
    public Guid StudentId { get; set; }
}
