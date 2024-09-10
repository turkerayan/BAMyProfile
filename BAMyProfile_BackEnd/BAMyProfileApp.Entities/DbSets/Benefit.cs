using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

public class Benefit : AuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<JobBenefit> JobBenefits { get; set; }
}