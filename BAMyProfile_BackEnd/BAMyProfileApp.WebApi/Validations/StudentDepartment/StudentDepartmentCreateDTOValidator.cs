using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.StudentDepartment;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentDepartmentCreateDTOValidator : AbstractValidator<StudentDepartmentCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentDepartmentCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.DepartmentId)
            .NotEmpty().WithMessage(_localizer[Messages.DepartmentIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
