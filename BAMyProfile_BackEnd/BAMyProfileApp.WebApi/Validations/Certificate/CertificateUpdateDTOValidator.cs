using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Certificate;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Certificate;

public class CertificateUpdateDTOValidator : AbstractValidator<CertificateUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public CertificateUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(r => r.Id).NotNull()
                        .NotEmpty().WithMessage(_localizer[Messages.CertificateIdRequired]);

        RuleFor(r => r.Name).NotEmpty().WithMessage(_localizer[Messages.CertificateNameCannotBeEmpty])
                            .NotNull()
                            .MinimumLength(2).WithMessage(_localizer[Messages.CertificateNameCannotBeLessThan2Letters])
                            .MaximumLength(256).WithMessage(_localizer[Messages.CertificateNameCannotExceed256Letters])
                            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer[Messages.CertificateNameCanContainLettersAndNumbers]);

        RuleFor(r => r.CertificateDate).NotNull()
                                       .NotEmpty().WithMessage(_localizer[Messages.CertificateDateCannotBeEmpty])
                                       .LessThanOrEqualTo(DateTime.Now);
        
        RuleFor(r => r.Description).NotEmpty().WithMessage(_localizer[Messages.CertificateDescriptionCannotBeEmpty])
                    .NotNull()
                    .MinimumLength(2).WithMessage(_localizer[Messages.CertificateDescriptionCannotBeLessThan2Letters])
                    .MaximumLength(256).WithMessage(_localizer[Messages.CertificateDescriptionCannotExceed256Letters])
                    .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s.,?!]+$").WithMessage(_localizer[Messages.CertificateDescriptionCanContainLettersAndNumbers]);
        
        //RuleFor(r => r.File).NotEmpty().WithMessage(_localizer[Messages.CertificateFileCannotBeEmpty])
        //            .NotNull()
        //            .Must(cf => cf.Equals("image/jpeg") || cf.Equals("image/jpg") || cf.Equals("application/pdf")).WithMessage(_localizer[Messages.CertificateFileTypeFail]);


        //RuleFor(r => r.AchievementStatus).NotNull()
        //                                 .NotEmpty().WithMessage(_localizer[Messages.CertificateAchievementStatusCannotBeEmpty]);
    }
}
