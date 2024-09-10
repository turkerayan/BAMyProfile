using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

/// <summary>
/// Junction table for Skill and Job Requirement
/// </summary>
public class JobSkill : AuditableEntity
{
    public Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
    public Guid JobId { get; set; }
    public virtual Job Job { get; set; }
}
