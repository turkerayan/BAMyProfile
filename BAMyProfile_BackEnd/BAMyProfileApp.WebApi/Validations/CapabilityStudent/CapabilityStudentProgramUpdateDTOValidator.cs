using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.CapabilityStudent;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class CapabilityStudentUpdateDTOValidator : AbstractValidator<CapabilityStudentUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public CapabilityStudentUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.CapabilityStudentIdRequired])
            .NotNull();

        RuleFor(dto => dto.CapabilityId)
            .NotEmpty().WithMessage(_localizer[Messages.CapabilityIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
