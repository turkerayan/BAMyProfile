using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.JobCandidate
{
    public class JobCandidateUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public Guid CandidateId { get; set; }
    }
}
