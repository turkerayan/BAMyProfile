using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Languages;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.WebApi.Validations.Language;

public class LanguageUpdateValidator: AbstractValidator<LanguagesUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public LanguageUpdateValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;
        RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.LanguagesIdRequired]);

        RuleFor(r => r.LanguageName).NotEmpty().WithMessage(_localizer["LanguageNameCannotBeEmpty"])
                             .NotNull().MinimumLength(2).WithMessage(_localizer["LanguageNameCannotExceed2Letters"])
                                  .MaximumLength(255).WithMessage(_localizer["LanguageNameCannotExceed255Letters"]).Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı]+$").WithMessage(_localizer["LanguageNameCanOnlyContainLetters"]);
        RuleFor(r => r.Level).NotNull().NotEmpty().WithMessage(_localizer["LanguageLevelCannotBeEmpty"]).
            IsInEnum().WithMessage(_localizer["LanguageLevelCanOnlyContainNumbers"]);
    }
}








