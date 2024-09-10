using BAMyProfileApp.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Cv;

public class CvUpdateDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Profile { get; set; }
    public Guid StudentId { get; set; }
}
