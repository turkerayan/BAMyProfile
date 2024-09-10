using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Certificate;

public class CertificateListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CertificateDate { get; set; }
    public string Description { get; set; }
    public string? File { get; set; }



}
