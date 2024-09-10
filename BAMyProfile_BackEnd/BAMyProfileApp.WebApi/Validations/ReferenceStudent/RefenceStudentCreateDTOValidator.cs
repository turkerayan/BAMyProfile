using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ReferenceStudent;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class ReferenceStudentCreateDTOValidator : AbstractValidator<ReferenceStudentCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public ReferenceStudentCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.ReferenceId)
            .NotEmpty().WithMessage(_localizer["ReferenceIdNotEmpty"])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
