namespace BAMyProfileApp.Dtos.JobBenefit;

public class JobBenefitUpdateDTO
{
    public Guid Id { get; set; }
    public Guid JobId { get; set; }
    public Guid BenefitId { get; set; }
}
