using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.References;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text.RegularExpressions;

namespace BAMyProfileApp.WebApi.Validations.Reference
{
    public class ReferenceCreateDTOValidator : AbstractValidator<ReferenceCreateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer;
        public ReferenceCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
        {
            _localizer = localizer;
            RuleFor(dto => dto.Name).NotEmpty().WithMessage(_localizer["ReferenceNameNotEmptyMessage"])
            .Must(BeValidName).WithMessage(_localizer["ReferenceNameMustConsistOfLetersOnly"]);
            RuleFor(dto => dto.Company).NotEmpty().WithMessage(_localizer["ReferenceCompanyCannotBeLeftBlank"]);
            RuleFor(dto => dto.Address).NotEmpty().WithMessage(_localizer["ReferenceAdressCannotBeLeftBlank"])
            .MinimumLength(2).WithMessage(_localizer["ReferenceAdressMustBeAtLeastTwoCharacters"]);
            //Title icin eklenen validasyonlar
            RuleFor(dto => dto.Title)
            .NotEmpty().WithMessage(_localizer["ReferenceTitleCannotBeLeftBlank"])
            .MinimumLength(2).WithMessage(_localizer["ReferenceTitleMustBeAtLeastTwoCharacters"])
            .MaximumLength(50).WithMessage(_localizer["ReferenceTitleMustBeAtMostFiftyCharacters"])
            .Must(title => !title.Any(char.IsDigit)).WithMessage(_localizer["ReferenceTitleCannotContainNumbers"]);
            //Email için eklenen validasyonlar
            RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(_localizer["ReferenceEmailCannotBeLeftBlank"])
            .EmailAddress().WithMessage(_localizer["ReferenceEmailMustContainAtSymbol"]);
            //PhoneNumber için eklenen validasyonlar
            RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage(_localizer["ReferencePhoneNumberCannotBeLeftBlank"])
            .Matches(@"^0\d{10}$").WithMessage(_localizer["ReferencePhoneNumberMustBeElevenDigitsAndStartWithZero"]);

        }
        // Yardımcı metot
        private bool BeValidName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            // İsim sadece harf içermeli
            return Regex.IsMatch(name, @"^([a-zA-ZğüşöçıİĞÜŞÖÇ\s]+)$");
        }
    }
}
