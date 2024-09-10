﻿using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.StudentCertificate;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentCertificateUpdateDTOValidator : AbstractValidator<StudentCertificateUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentCertificateUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

                RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.StudentCertificateIdRequired])
            .NotNull();

        RuleFor(dto => dto.CertificateId)
            .NotEmpty().WithMessage(_localizer[Messages.CertificateIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
