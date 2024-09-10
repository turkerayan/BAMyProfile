using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.EventStudent;

public class EventStudentUpdateDTO
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid StudentId { get; set; }
}
