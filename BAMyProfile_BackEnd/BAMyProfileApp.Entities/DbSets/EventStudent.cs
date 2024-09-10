using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;
public class EventStudent:AuditableEntity
{
	public Guid StudentId { get; set; }
	public virtual Student? Student { get; set; }

    public Guid EventId { get; set; }
	public virtual Event? Event { get; set; }

}
