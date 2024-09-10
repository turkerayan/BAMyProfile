using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;

namespace BAMyProfileApp.Entities.DbSets;

public class Job : AuditableEntity
{
    public string Position { get; set; }
    public string Description { get; set; }
    public string Experience { get; set; }
    public string Education { get; set; }
    public decimal Salary { get; set; }
    public Remote WorkLocation { get; set; }
    public JobStatus JobStatus { get; set; }

    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }

    public virtual ICollection<JobSkill> JobSkills { get; set; }
    public virtual ICollection<JobBenefit> JobBenefits { get; set; }
    public virtual ICollection<Application> Applications { get; set; }
    public virtual ICollection<JobCandidate> JobCandidate { get; set; }

}
