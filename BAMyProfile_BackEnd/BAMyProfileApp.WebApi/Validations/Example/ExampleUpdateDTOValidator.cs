using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Example;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class ExampleUpdateDTOValidator : AbstractValidator<ExampleUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public ExampleUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.ExampleIdRequired])
            .NotNull();

        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(_localizer[Messages.ExampleNameRequired])
            .NotNull();

    }
}
