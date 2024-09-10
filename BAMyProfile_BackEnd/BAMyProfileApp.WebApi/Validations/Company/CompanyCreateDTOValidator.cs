using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Dtos.Company;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Company
{
    public class CompanyCreateDTOValidator : AbstractValidator<CompanyCreateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CompanyCreateDTOValidator(IStringLocalizer<MessageResources> localizer) 
        {
            _localizer = localizer;

            RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(_localizer[Messages.CompanyNameNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(_localizer[Messages.CompanyNameMinLength])
            .MaximumLength(50).WithMessage(_localizer[Messages.CompanyNameMaxLength]);

            RuleFor(dto => dto.Location)
             .NotEmpty().WithMessage(_localizer[Messages.CompanyLocationNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(_localizer[Messages.CompanyLocationMinLength])
            .MaximumLength(50).WithMessage(_localizer[Messages.CompanyLocationMaxLength]);

            RuleFor(dto => dto.Sector)
             .NotEmpty().WithMessage(_localizer[Messages.CompanySectorNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(_localizer[Messages.CompanySectorMinLength])
            .MaximumLength(50).WithMessage(_localizer[Messages.CompanySectorMaxLength]);

            RuleFor(dto => dto.GeneralInformation)
            .NotEmpty().WithMessage(_localizer[Messages.CompanyGeneralInformationNotEmpty])
            .NotNull()
            .MinimumLength(2).WithMessage(_localizer[Messages.CompanyGeneralInformationMinLength])
            .MaximumLength(200).WithMessage(_localizer[Messages.CompanyGeneralInformationMaxLength]);
        }
    }
}
