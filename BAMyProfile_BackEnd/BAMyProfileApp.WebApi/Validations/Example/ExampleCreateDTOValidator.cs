using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Example;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class ExampleCreateDTOValidator : AbstractValidator<ExampleCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public ExampleCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(_localizer[Messages.ExampleNameRequired])
            .NotNull();

    }
}
