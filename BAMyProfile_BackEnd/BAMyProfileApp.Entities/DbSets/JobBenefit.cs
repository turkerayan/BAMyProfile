using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

public class JobBenefit : AuditableEntity
{
    public Guid JobId { get; set; }
    public virtual Job Job { get; set; }
    public Guid BenefitId { get; set; }
    public virtual Benefit Benefit { get; set; }
}