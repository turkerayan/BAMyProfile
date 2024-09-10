using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.StudentCertificate;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentCertificateCreateDTOValidator : AbstractValidator<StudentCertificateCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentCertificateCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.CertificateId)
            .NotEmpty().WithMessage(_localizer[Messages.CertificateIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
