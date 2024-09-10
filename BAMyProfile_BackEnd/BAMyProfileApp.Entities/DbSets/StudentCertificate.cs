using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

public class StudentCertificate : AuditableEntity
{
    public Guid StudentId { get; set; }
    public Guid CertificateId { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual Certificate? Certificate { get; set; }
}
