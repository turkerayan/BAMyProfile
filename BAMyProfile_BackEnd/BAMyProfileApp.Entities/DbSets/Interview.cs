using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Interview :AuditableEntity
{
    public string InterviewName { get; set; }
    public string InterviewerName { get; set; }
    public DateTime InterviewDate { get; set; }
    public string InterviewLocation { get; set; }
    public string? InterviewNotes { get; set; }
    public string PositionInterviewedFor { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; }


}

