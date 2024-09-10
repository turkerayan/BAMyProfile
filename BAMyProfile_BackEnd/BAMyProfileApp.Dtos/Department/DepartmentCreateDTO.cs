using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Department;

public class DepartmentCreateDTO
{
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
}
