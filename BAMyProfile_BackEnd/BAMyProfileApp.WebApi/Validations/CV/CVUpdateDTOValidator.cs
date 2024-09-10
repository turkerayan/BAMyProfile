using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Cv;
using FluentValidation;
using Microsoft.Extensions.Localization;
using BAMyProfileApp.Business.Constants;
namespace BAMyProfileApp.WebApi.Validations.CV;

public class CVUpdateDTOValidator : AbstractValidator<CvUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public CVUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;
        RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer[Messages.CvIdRequired]).NotNull();
        RuleFor(cp => cp.StudentId).NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired]);
        RuleFor(x => x.Title).NotEmpty().WithMessage(_localizer["CvTitleNotEmptyMessage"])
            .MinimumLength(2).WithMessage(_localizer["CvTitleLengthMessageMin"])
            .MaximumLength(128).WithMessage(_localizer["CvTitleLengthMessage"])
            .NotNull()
            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["CvTitleFormatMessage"]);


        RuleFor(x => x.Profile).NotEmpty().WithMessage(_localizer["CvProfileNotEmptyMessage"])
            .MinimumLength(2).WithMessage(_localizer["CvProfileLengthMessageMin"])
            .MaximumLength(512).WithMessage(_localizer["CvProfileLengthMessage"])
            .NotNull()
            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["CvProfileFormatMessage"]);
    }
}
