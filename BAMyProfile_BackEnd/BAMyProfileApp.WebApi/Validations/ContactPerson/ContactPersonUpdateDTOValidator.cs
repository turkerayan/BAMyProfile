using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ContactPerson;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.ContactPerson
{
    public class ContactPersonUpdateDTOValidator : AbstractValidator<ContactPersonUpdateDto>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;

        public ContactPersonUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;

            RuleFor(cp => cp.Id).NotNull()
                .NotEmpty().WithMessage(_localizer[Messages.ContactPersonIdIsRequiredForUpdate]);

            RuleFor(cp => cp.PersonFullName).NotEmpty().WithMessage(_localizer[Messages.ContactPersonNameNotEmmpty])
                                           .MinimumLength(2).WithMessage(_localizer[Messages.ContactPersonFullNameMinLength])
                                           .MaximumLength(256).WithMessage(_localizer[Messages.ContactPersonNameNotExceed256Letters]);

            RuleFor(cp => cp.CompanyId).NotEmpty().WithMessage(_localizer[Messages.ContactPersonCompanyIdNotEmpty]);
                                        

            RuleFor(cp => cp.PersonEmail).NotEmpty().WithMessage(_localizer[Messages.ContactPersonEmailNotEmpty]);

            RuleFor(cp => cp.PersonPhoneNumber).NotEmpty().WithMessage(_localizer[Messages.ContactPersonPhoneNumberNotEmpty])
                                               .Must(x => !string.IsNullOrEmpty(x) && x.StartsWith("0")).WithMessage(_localizer[Messages.PhoneNumberMustBeStartingWith0])
                                               .Length(11).WithMessage(_localizer[Messages.PhoneNumberMustBe11Digit]);

            RuleFor(cp => cp.Department).NotEmpty().WithMessage(_localizer[Messages.ContactPersonDepartmentNotEmpty])
                                        .MinimumLength(2).WithMessage(_localizer[Messages.ContactPersonDepartmentMinLength])
                                        .MaximumLength(256).WithMessage(_localizer[Messages.ContactPersonDepartmentNotExceed256Letters]);

            RuleFor(cp => cp.Position).NotEmpty().WithMessage(_localizer[Messages.ContactPersonPositionNotEmpty])
                                      .MinimumLength(2).WithMessage(_localizer[Messages.ContactPersonPositionMinLength])
                                      .MaximumLength(50).WithMessage(_localizer[Messages.ContactPersonPositionNotExceed50Letters]);


        }
    }
}
