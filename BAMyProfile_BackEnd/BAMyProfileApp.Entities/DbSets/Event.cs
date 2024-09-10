using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Event : AuditableEntity
{
    public string Title { get; set; } = default!;
    public DateTime Date { get; set; }
    public byte[]? File { get; set; }
    public EventType EventType { get; set; }
    public string? Link { get; set; }
    public virtual IEnumerable<EventStudent>? EventStudents { get; set; }
}
