using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Skill;

public class SkillCreateDTOValidator : AbstractValidator<SkillCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public SkillCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage(_localizer[Messages.SkillNameNotEmpty])
        .NotNull();

    }
}
