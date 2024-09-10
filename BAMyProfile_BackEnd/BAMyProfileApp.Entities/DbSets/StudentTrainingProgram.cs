using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class StudentTrainingProgram :AuditableEntity
{
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; }

    public Guid TrainingProgramId { get; set; }
    public virtual TrainingProgram? TrainingProgram { get; set; }
}
