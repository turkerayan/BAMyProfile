using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.StudentLanguage;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentLanguageCreateDTOValidator : AbstractValidator<StudentLanguageCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentLanguageCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.LanguageId)
            .NotEmpty().WithMessage(_localizer[Messages.LanguagesIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
