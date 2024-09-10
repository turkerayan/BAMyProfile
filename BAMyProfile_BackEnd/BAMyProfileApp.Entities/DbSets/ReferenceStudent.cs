using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class ReferenceStudent : AuditableEntity
    {
        // Foreign key for Student
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }


        // Foreign key for Reference
        public Guid ReferenceId { get; set; }
        public virtual Reference? Reference { get; set; }
    }

}
