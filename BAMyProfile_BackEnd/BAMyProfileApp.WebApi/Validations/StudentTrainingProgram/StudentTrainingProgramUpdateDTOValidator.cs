using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using BAMyProfileApp.Dtos.Skill;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class StudentTrainingProgramUpdateDTOValidator : AbstractValidator<StudentTrainingProgramUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public StudentTrainingProgramUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

                RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(_localizer[Messages.StudentTrainingProgramIdRequired])
            .NotNull();

        RuleFor(dto => dto.TrainingProgramId)
            .NotEmpty().WithMessage(_localizer["TraningProgramIdRequired"])
            .NotNull();

        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
    }
}
