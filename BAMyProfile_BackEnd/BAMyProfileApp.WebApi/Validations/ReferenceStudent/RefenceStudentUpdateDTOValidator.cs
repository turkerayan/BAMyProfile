using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.ReferenceStudent;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class ReferenceStudentUpdateDTOValidator : AbstractValidator<ReferenceStudentUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public ReferenceStudentUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.RefenreceStudentIdRequired])
            .NotNull();

        RuleFor(dto => dto.ReferenceId)
            .NotEmpty().WithMessage(_localizer["ReferenceIdNotEmpty"])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
