using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.StudentTrainingProgram;

public class StudentTrainingProgramUpdateDTO
{
    public Guid Id { get; set; }
    public Guid TrainingProgramId { get; set; }
    public Guid StudentId { get; set; }
}
