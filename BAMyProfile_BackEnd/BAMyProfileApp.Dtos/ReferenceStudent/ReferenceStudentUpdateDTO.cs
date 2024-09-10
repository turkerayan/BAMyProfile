using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.ReferenceStudent;

public class ReferenceStudentUpdateDTO
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public Guid StudentId { get; set; }
}
