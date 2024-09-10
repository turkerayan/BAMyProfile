using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.JobBenefit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class JobBenefitCreateDTOValidator : AbstractValidator<JobBenefitCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public JobBenefitCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.BenefitId)
            .NotEmpty().WithMessage(_localizer[Messages.BenefitIdRequired])
            .NotNull();

        RuleFor(dto => dto.JobId)
            .NotEmpty().WithMessage(_localizer[Messages.JobIdRequired])
            .NotNull();

    }
}
