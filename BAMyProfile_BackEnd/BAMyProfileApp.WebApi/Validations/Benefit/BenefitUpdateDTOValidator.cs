using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Benefit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Benefit;

public class BenefitUpdateDTOValidator : AbstractValidator<BenefitUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public BenefitUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)            
            .NotEmpty().WithMessage(_localizer[Messages.BenefitIdRequired]);

        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(_localizer[Messages.BenefitNameNotEmpty])
            .NotNull();
    }
}
