using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class JobCandidate: AuditableEntity
    {
        public Guid JobId { get; set; }
        public virtual Job? Job { get; set; }
        public Guid CandidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
