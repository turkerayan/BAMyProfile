using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class StudentLanguage:AuditableEntity
    {
        public Guid StudentId { get; set; }
        public Guid LanguageId { get; set; }

        // Navigation Property
        public virtual Student? Student { get; set; }

        public virtual Languages? Language { get; set; }
    }
}
