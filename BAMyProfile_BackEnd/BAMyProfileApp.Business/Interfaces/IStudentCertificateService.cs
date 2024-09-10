using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.StudentCertificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IStudentCertificateService
{
    Task<IResult> CreateAsync(StudentCertificateCreateDTO studentCertificateCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(StudentCertificateUpdateDTO studentCertificateUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}

