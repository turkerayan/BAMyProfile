using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.JobBenefit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class JobBenefitUpdateDTOValidator : AbstractValidator<JobBenefitUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public JobBenefitUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.JobBenefitIdRequired])
            .NotNull();

        RuleFor(dto => dto.BenefitId)
            .NotEmpty().WithMessage(_localizer[Messages.BenefitIdRequired])
            .NotNull();

        RuleFor(dto => dto.JobId)
            .NotEmpty().WithMessage(_localizer[Messages.JobIdRequired])
            .NotNull();
    }
}
