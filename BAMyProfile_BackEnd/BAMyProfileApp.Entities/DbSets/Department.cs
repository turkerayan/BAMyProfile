using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Department : AuditableEntity
{
    public string Name { get; set; }

    // Bölüm, sadece bir fakülteye ait olabilir
    public Guid FacultyId { get; set; }
    public virtual Faculty Faculty { get; set; }
    public virtual IEnumerable<StudentDepartment>? DepartmentStudents { get; set; }
}
