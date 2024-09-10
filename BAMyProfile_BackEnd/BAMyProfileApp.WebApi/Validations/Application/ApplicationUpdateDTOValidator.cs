using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Application
{
    public class ApplicationUpdateDTOValidator:AbstractValidator<ApplicationUpdateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;

        public ApplicationUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;

            RuleFor(dto => dto.ApplicationDate)
               .NotEmpty().WithMessage(_localizer[Messages.ApplicationDateRequired])
               .Must(BeValidDate).WithMessage(_localizer[Messages.InvalidDateFormat])
               .Must(BeWithinYear).WithMessage(_localizer[Messages.ApplicationDateWithinYear]);

            RuleFor(dto => dto.ApplicationStatus)
                .NotEmpty().WithMessage(_localizer[Messages.ApplicationStatusForRequired]);

            RuleFor(dto => dto.Description)
              .MaximumLength(500).WithMessage(_localizer[Messages.ApplicationDescriptionMaxLength]);

            RuleFor(dto => dto.CandidateId)
                .NotEmpty().WithMessage(_localizer[Messages.CandidateIdRequired]);

            RuleFor(dto => dto.JobId)
                .NotEmpty().WithMessage(_localizer[Messages.JobIdRequired]);
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
