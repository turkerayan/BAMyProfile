using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Benefit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Benefit;

public class BenefitCreateDTOValidator : AbstractValidator<BenefitCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public BenefitCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage(_localizer[Messages.BenefitNameNotEmpty])
        .NotNull();
    }
}
