using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.StudentLanguage;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentLanguageUpdateDTOValidator : AbstractValidator<StudentLanguageUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentLanguageUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

                RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.StudentLanguageIdRequired])
            .NotNull();

        RuleFor(dto => dto.LanguageId)
            .NotEmpty().WithMessage(_localizer[Messages.LanguagesIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
