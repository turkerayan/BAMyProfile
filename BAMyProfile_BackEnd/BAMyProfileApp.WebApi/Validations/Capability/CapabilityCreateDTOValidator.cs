using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Capability;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Drawing.Text;

namespace BAMyProfileApp.WebApi.Validations.Capability;

public class CapabilityCreateDTOValidator : AbstractValidator<CapabilityCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public CapabilityCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.CapabilityName)
                .NotEmpty().WithMessage(_localizer[Messages.CapabilityNameCannotBeEmpty])
                .NotNull()
                .MinimumLength(2).WithMessage(_localizer[Messages.CapabilityNameMustBeAtLeast2Characters])
                .MaximumLength(256).WithMessage(_localizer[Messages.CapabilityNameCannotExceed256Letters]);
                

    }
}
