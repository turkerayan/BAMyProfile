using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.EventStudent;

public class EventStudentCreateDTO
{
    public Guid EventId { get; set; }
    public Guid StudentId { get; set; }
}