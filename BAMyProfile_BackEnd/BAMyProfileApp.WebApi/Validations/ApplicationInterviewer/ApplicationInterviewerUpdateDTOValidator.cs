﻿using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.ApplicationInterviewer
{
	public class ApplicationInterviewerUpdateDTOValidator : AbstractValidator<ApplicationInterviewerUpdateDTO>
	{
		private readonly IStringLocalizer<MessageResources> _localizer;
		public ApplicationInterviewerUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;
			RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewerIdRequired]);
			RuleFor(x => x.FirstName)
					 .NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewerNameCannotBeEmpty])
					 .NotNull().MinimumLength(3).MaximumLength(30)
					 .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı]+$").WithMessage(_localizer[Messages.ApplicationInterviewerNameCanOnlyContainLetters]);

			RuleFor(x => x.LastName)
					.NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewerSurnameCannotBeEmpty])
					.NotNull().MinimumLength(2).MaximumLength(30)
					.Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı]+$").WithMessage(_localizer[Messages.ApplicationInterviewerSurnameCanOnlyContainLetters]);
			RuleFor(x => x.Email)
					 .NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewerEmailCannotBeEmpty])
					 .EmailAddress().WithMessage(_localizer[Messages.PleaseEnterValidEmail]);
			RuleFor(x => x.PhoneNumber)
					.Length(11).WithMessage(_localizer[Messages.PhoneNumberMustBe11Digit])
					.Must(x => x.StartsWith("0")).WithMessage(_localizer[Messages.PhoneNumberMustBeStartingWith0])
					.Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage(_localizer[Messages.PhoneNumberCanOnlyContainNumber])
					.When(x => !string.IsNullOrEmpty(x.PhoneNumber));

			RuleFor(x => x.Gender)
					 .NotEmpty().WithMessage(_localizer[Messages.GenderMustBeSelected])
					 .Must(x => x == true || x == false).WithMessage(_localizer[Messages.PleaseSelectValidGender]);

			RuleFor(x => x.DateOfBirth)
					 .NotEmpty().WithMessage(_localizer[Messages.DateOfBirthCannotBeEmpty])
					 .Must(x => DateTime.Now.Year - x.Year >= 18 && x >= DateTime.Parse("1900-01-01"))
					 .WithMessage(_localizer[Messages.PleaseEnterValidDateofBirth]);

			RuleFor(x => x.Address)
					.MinimumLength(2).WithMessage(_localizer[Messages.AddressMustContainAtLeast2Characters])
					.MaximumLength(200).WithMessage(_localizer[Messages.AddressCanBeUpTo200Characters])
					.When(x => x.Address != null);

			RuleFor(dto => dto.ApplicationInterviewId).NotEmpty().WithMessage(_localizer[Messages.ApplicationInterviewIdRequired]);
		}
    }
}
