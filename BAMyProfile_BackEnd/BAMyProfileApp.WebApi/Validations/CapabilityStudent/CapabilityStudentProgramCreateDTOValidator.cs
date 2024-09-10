using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.CapabilityStudent;
using BAMyProfileApp.Dtos.JobSkill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class CapabilityStudentCreateDTOValidator : AbstractValidator<CapabilityStudentCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public CapabilityStudentCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.CapabilityId)
            .NotEmpty().WithMessage(_localizer[Messages.CapabilityIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
