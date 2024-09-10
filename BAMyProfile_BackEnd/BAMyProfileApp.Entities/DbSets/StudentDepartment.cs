using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class StudentDepartment : AuditableEntity
{
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; }

    public Guid DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
}
