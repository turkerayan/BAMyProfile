using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.StudentDepartment;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentDepartmentUpdateDTOValidator : AbstractValidator<StudentDepartmentUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentDepartmentUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

                RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.StudentDepartmentIdRequired])
            .NotNull();

        RuleFor(dto => dto.DepartmentId)
            .NotEmpty().WithMessage(_localizer[Messages.DepartmentIdRequired])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
