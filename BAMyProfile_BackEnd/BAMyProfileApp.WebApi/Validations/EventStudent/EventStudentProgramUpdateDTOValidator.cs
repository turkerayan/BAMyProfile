using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.EventStudent;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.JobSkill;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class EventStudentUpdateDTOValidator : AbstractValidator<EventStudentUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public EventStudentUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.EventStudentIdRequired])
            .NotNull();

        RuleFor(dto => dto.EventId)
            .NotEmpty().WithMessage(_localizer[Messages.EventIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
