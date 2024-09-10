using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Skill;

public class SkillUpdateDTOValidator : AbstractValidator<SkillUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public SkillUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.SkillIdRequired]);

        RuleFor(dto => dto.Name)
           .NotEmpty().WithMessage(_localizer[Messages.SkillNameNotEmpty])
           .NotNull();

        //RuleFor(dto => dto.Name)
        //    .NotEmpty().WithMessage(_localizer["SkillNotEmpty"])
        //    .NotNull();

    }
}
