using BAMyProfileApp.Entities.Enums;

namespace BAMyProfileApp.Dtos.Job;

public class JobListDTO
{
    public Guid Id { get; set; }
    public string Position { get; set; }
    public string Description { get; set; }
    public string Experience { get; set; }
    public string Education { get; set; }
    public decimal Salary { get; set; }
    public Guid CompanyId { get; set; }
    public Remote WorkLocation { get; set; }
    public JobStatus JobStatus { get; set; }
    public ICollection<string> JobSkillNames { get; set; }
    public ICollection<string> JobBenefitNames { get; set; }
}
