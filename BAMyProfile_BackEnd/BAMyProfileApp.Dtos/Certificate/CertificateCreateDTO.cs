using Microsoft.AspNetCore.Http;

namespace BAMyProfileApp.Dtos.Certificate;

public class CertificateCreateDTO
{
    public string Name { get; set; }
    public DateTime CertificateDate { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    
}
