﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.StudentCertificate;

public class StudentCertificateListDTO
{
    public Guid Id { get; set; }
    public Guid CertificateId { get; set; }
    public Guid StudentId { get; set; }
}