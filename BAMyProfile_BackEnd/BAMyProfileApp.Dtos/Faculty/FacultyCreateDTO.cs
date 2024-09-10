using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Faculty;

public class FacultyCreateDTO
{
    public string Name { get; set; }
    public Guid UniversityId { get; set; }
}
