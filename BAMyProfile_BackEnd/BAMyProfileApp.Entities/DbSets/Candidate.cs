using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class Candidate: BaseUser
    {
        public virtual Student Student { get; set; }
        public Guid StudentId { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<JobCandidate> JobCandidate { get; set; }
    }
}
