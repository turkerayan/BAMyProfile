using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Job;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Job;

public class JobUpdateDTOValidator : AbstractValidator<JobUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;

    public JobUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.JobIdRequired]);

        RuleFor(dto => dto.Position)
            .NotEmpty().WithMessage(_localizer[Messages.JobPositionNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(localizer[Messages.JobPositionMustBeAtLeast2Characters])
            .MaximumLength(100).WithMessage(localizer[Messages.JobPositionCanNotExceed100Characters]);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage(_localizer[Messages.JobDescriptionNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(localizer[Messages.JobDescriptionMustBeAtLeast2Characters])
            .MaximumLength(256).WithMessage(localizer[Messages.JobDescriptionCanNotExceed256Characters]);

        RuleFor(dto => dto.Experience)
            .NotEmpty().WithMessage(_localizer[Messages.JobExperienceNotEmpty])
            .NotNull()
            .MinimumLength(1).WithMessage(localizer[Messages.JobExperienceMustBeAtLeast1Characters])
            .MaximumLength(256).WithMessage(localizer[Messages.JobExperienceCanNotExceed256Characters])
            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer[Messages.JobExperienceFormat]);

        RuleFor(dto => dto.Education)
            .NotEmpty().WithMessage(_localizer[Messages.JobEducationNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(localizer[Messages.JobEducationMustBeAtLeast2Characters])
            .MaximumLength(256).WithMessage(localizer[Messages.JobEducationCanNotExceed256Characters])
            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer[Messages.JobEducationFormat]);

        RuleFor(dto => dto.Salary)
            .NotEmpty().WithMessage(_localizer[Messages.JobSalaryNotEmpty])
            .NotNull()
            .GreaterThan(0).WithMessage(_localizer[Messages.JobSalaryGreaterThanZero]);

        RuleFor(dto => dto.WorkLocation)
            .NotEmpty().WithMessage(_localizer[Messages.JobWorkLocationNotEmpty])
            .NotNull()
            .IsInEnum();

        RuleFor(dto => dto.JobStatus)
            .NotEmpty().WithMessage(_localizer[Messages.JobStatusNotEmpty])
            .NotNull()
            .IsInEnum();

        RuleFor(dto => dto.CompanyId)
            .NotEmpty()
            .WithMessage(_localizer[Messages.CompanyAddFail])
            .NotNull();
    }
}
