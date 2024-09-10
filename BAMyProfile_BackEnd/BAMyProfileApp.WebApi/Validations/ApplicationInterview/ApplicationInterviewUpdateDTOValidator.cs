using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterview;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.ApplicationInterview
{
	public class ApplicationInterviewUpdateDTOValidator : AbstractValidator<ApplicationInterviewUpdateDTO>
	{
		private readonly IStringLocalizer<MessageResources> _localizer;
		public ApplicationInterviewUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
		{

			_localizer = localizer;

			RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewIdRequired]);

            RuleFor(dto => dto.ApplicationId)
                .NotEmpty().WithMessage(_localizer[Messages.ApplicationIdRequired]);

            RuleFor(dto => dto.CompanyId)
				.NotEmpty().WithMessage(_localizer[Messages.CompanyIdRequired]);

			RuleFor(dto => dto.InterviewDate)
			   .NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewDateRequired])
			   .Must(BeValidDate).WithMessage(_localizer[Messages.InvalidDateFormat])
			   .Must(BeWithinYear).WithMessage(_localizer[Messages.ApplicationInterviewDateWithinYear]);

            RuleFor(dto => dto.InterviewComment)
              .NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewCommentsRequired])
              .MaximumLength(500).WithMessage(_localizer[Messages.ApplicationInterviewCommentsMaxLength]);

            RuleFor(dto => dto.InterviewStatus)
				.NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewStatusForRequired]);

		}

		private bool BeValidDate(DateTime date)
		{
			return date >= DateTime.Today;
		}
		private bool BeWithinYear(DateTime date)
		{
			return date.Year == DateTime.Today.Year;
		}
		
	}
}
