using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.TrainingProgram;

public class TrainingProgramCreateDTO
{
    public string Name { get; set; } 
    public int TimeInHours { get; set; } 
    public string Content { get; set; } 
}
