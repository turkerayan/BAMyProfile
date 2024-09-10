using BAMyProfileApp.Core.Entities.Base;

namespace BAMyProfileApp.Entities.DbSets;

public class Certificate : AuditableEntity
{
    public string Name { get; set; } = null!;
    public DateTime CertificateDate { get; set; }
    public string Description { get; set; } = null!;
    public byte[]? File { get; set; }


    // Navigation Property
    public virtual IEnumerable<StudentCertificate>? CertificateStudents { get; set; }
}
