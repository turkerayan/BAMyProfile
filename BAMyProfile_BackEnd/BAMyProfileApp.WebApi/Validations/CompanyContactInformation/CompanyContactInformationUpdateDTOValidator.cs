using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Dtos.CompanyContactInformation;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.CompanyContactInformation
{
    public class CompanyContactInformationUpdateDTOValidator : AbstractValidator<CompanyContactInformationUpdateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CompanyContactInformationUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;

            RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.CompanyContactInformationIdRequired]);

            RuleFor(x => x.PhoneNumber)
                     .NotEmpty().WithMessage(_localizer[Messages.CompanyContactInformationPhoneNumberNotEmpty])
                     .Length(11).WithMessage(_localizer[Messages.PhoneNumberMustBe11Digit])
                     .Must(x => !string.IsNullOrEmpty(x) && x.StartsWith("0")).WithMessage(_localizer[Messages.PhoneNumberMustBe11DigitsandStartingWith0])
                     .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage(_localizer[Messages.PhoneNumberCanOnlyContainNumber]);

            RuleFor(x => x.Email).NotEmpty().WithMessage(_localizer[Messages.CompanyContactInformationEmailNotEmpty]).EmailAddress().WithMessage(_localizer[Messages.PleaseEnterValidEmail]);

            RuleFor(dto => dto.Address).NotEmpty().WithMessage(_localizer[Messages.CompanyContactInformationAddressNotEmpty]).MinimumLength(2).WithMessage(_localizer[Messages.CompanyContactInformationAddressMinLength])
                      .MaximumLength(200).WithMessage(_localizer[Messages.CompanyContactInformationAddressMaxLength]);

            RuleFor(dto => dto.CompanyId).NotEmpty().WithMessage(_localizer[Messages.CompanyIdRequired]);
        }
    }
}
