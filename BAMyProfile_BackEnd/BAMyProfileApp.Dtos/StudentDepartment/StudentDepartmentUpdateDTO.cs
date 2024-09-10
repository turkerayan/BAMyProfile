using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.StudentDepartment;

public class StudentDepartmentUpdateDTO
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid StudentId { get; set; }
}
