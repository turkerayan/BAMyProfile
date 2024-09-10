using BAMyProfileApp.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Department;

public class DepartmentDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
    
}
