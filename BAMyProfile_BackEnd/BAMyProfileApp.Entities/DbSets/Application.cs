using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class Application: AuditableEntity
    {
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public ApplicationSuccessStatus? ApplicationSuccessStatus { get; set; }
        public string? Description { get; set; }
        public Guid CandidateId { get; set; }
        public Guid JobId { get; set; }
        //Nav Property
        public virtual Candidate Candidate { get; set; }
        public virtual ApplicationInterview ApplicationInterview { get; set; }
        public virtual Job Job { get; set; }
    }
}
