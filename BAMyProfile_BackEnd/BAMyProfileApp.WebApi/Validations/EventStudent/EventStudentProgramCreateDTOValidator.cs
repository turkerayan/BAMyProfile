using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.EventStudent;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class EventStudentCreateDTOValidator : AbstractValidator<EventStudentCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public EventStudentCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.EventId)
            .NotEmpty().WithMessage(_localizer[Messages.EventIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
