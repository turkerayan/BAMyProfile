using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.TrainingProgram;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.StudentTrainingProgram;

public class TrainingProgramCreateDTOValidator : AbstractValidator<TrainingProgramCreateDTO>
{
	private readonly IStringLocalizer<MessageResources> localizer;
    public TrainingProgramCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
		this.localizer = localizer;

		RuleFor(x => x.Name).NotEmpty().WithMessage(localizer["TrainingProgramTitleCannotBeEmpty"])
		  .MinimumLength(2).WithMessage(localizer["TrainingProgramTitlecannotbelessthan2letters"])
		  .MaximumLength(50).WithMessage(localizer["TrainingProgramTitleCannotExceed50Letters"])
		  .NotNull();

		RuleFor(x => x.Content).NotEmpty().WithMessage(localizer["ContentCannotBeEmpty"])
		  .MinimumLength(2).WithMessage(localizer["Contentcannotbelessthan2Letters"])
		  .MaximumLength(500).WithMessage(localizer["ContentCannotExceed500Letters"])
		  .NotNull();
		  

		RuleFor(x => x.TimeInHours).NotEmpty()
			.WithMessage(localizer["TrainingHoursCannotBeEmpty"])
			.GreaterThan(1)
			.WithMessage(localizer["MinimumOf2HoursOfTrainingCanBeEntered"])
			.NotNull();

	}
}
