using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.JobSkill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class JobSkillCreateDTOValidator : AbstractValidator<JobSkillCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public JobSkillCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.SkillId)
            .NotEmpty().WithMessage(_localizer[Messages.SkillIdRequired])
            .NotNull();

        RuleFor(dto => dto.JobId)
            .NotEmpty().WithMessage(_localizer[Messages.JobIdRequired])
            .NotNull();

    }
}
