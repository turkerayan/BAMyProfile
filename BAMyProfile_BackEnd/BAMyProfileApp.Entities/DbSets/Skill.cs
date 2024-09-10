using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

/// <summary>
/// The skill required for a job
/// </summary>
public class Skill : AuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<JobSkill> JobSkills { get; set; }
}
