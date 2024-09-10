using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Faculty;

public class FacultyUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UniversityId { get; set; }
}
