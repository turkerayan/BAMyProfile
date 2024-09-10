using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Employee;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Employee
{
    public class EmployeeCreateDTOValidator : AbstractValidator<EmployeeCreateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;

        public EmployeeCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage(_localizer[Messages.EmployeeFirstNameNotEmpty])
                .NotNull()
                .MinimumLength(2).WithMessage(_localizer[Messages.EmployeeFirstNameMustContainAtLeast2Characters])
                .MaximumLength(30).WithMessage(_localizer[Messages.EmployeFirstNameCanBeUpTo30Characters])
                .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı]+$").WithMessage(_localizer[Messages.EmployeFirstNameCanOnlyContainLetters]);

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage(_localizer[Messages.EmployeeLastNameNotEmpty])
                .NotNull()
                .MinimumLength(2).WithMessage(_localizer[Messages.EmployeeLastNameMustContainAtLeast2Characters])
                .MaximumLength(30).WithMessage(_localizer[Messages.EmployeeLastNameCanBeUpTo30Characters])
                .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı]+$").WithMessage(_localizer[Messages.EmployeLastNameCanOnlyContainLetters]);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(_localizer[Messages.EmployeeEmailNotEmpty])
                .EmailAddress().WithMessage(_localizer[Messages.EmployeeEmailMustBeCorrectFormat]);

            RuleFor(e => e.PhoneNumber)
                .Length(11).WithMessage(_localizer[Messages.PhoneNumberMustBe11Digit])
                .Must(e => e.StartsWith("0")).WithMessage(_localizer[Messages.PhoneNumberMustBeStartingWith0])
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                .WithMessage(_localizer[Messages.EmployeePhoneNumberCanOnlyContainNumber])
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

            RuleFor(e => e.Gender)
                .NotEmpty().WithMessage(_localizer[Messages.EmployeeGenderMustBeSelected])
                .Must(e => e == true || e == false).WithMessage(_localizer[Messages.EmployeePleaseSelectValidGender]);

            RuleFor(e => e.DateOfBirth)
                .NotEmpty().WithMessage(_localizer[Messages.DateOfBirthOfEmployeeCannotBeEmpty])
                .Must(e => DateTime.Now.Year - e.Year >= 18 && e >= DateTime.Parse("1900-01-01"))
                .WithMessage(_localizer[Messages.DateofBirthofEmployeeMustEnterValid]);

            RuleFor(e => e.Address)
                .MinimumLength(2).WithMessage(_localizer[Messages.AddressOfEmployeeMustContainAtLeast2Characters])
                .MaximumLength(200).WithMessage(_localizer[Messages.AddressOfEmployeeCanBeUpTo200Characters])
                .When(e => e.Address != null);

        }
    }
}
