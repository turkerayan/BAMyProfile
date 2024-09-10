using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentTrainingProgramCreateDTOValidator : AbstractValidator<StudentTrainingProgramCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentTrainingProgramCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.TrainingProgramId)
            .NotEmpty().WithMessage(_localizer["TraningProgramIdRequired"])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();

    }
}
