using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Faculty : AuditableEntity
{
    public string Name { get; set; }

    // Fakülte, sadece bir üniversiteye ait olabilir
    public Guid UniversityId { get; set; }
    public virtual University University { get; set; }

    // Her bir fakültenin birden fazla bölümü olabilir
    public virtual ICollection<Department> Departments { get; set; }
}
