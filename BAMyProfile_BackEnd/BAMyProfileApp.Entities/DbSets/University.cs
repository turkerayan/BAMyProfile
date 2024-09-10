using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class University : AuditableEntity
{
    public string Name { get; set; }

    // Her bir üniversitenin birden fazla fakültesi olabilir
    public virtual ICollection<Faculty> Faculties { get; set; }
}
