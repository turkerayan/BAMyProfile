using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Faculty;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Faculty;

public class FacultyCreateDTOValidator : AbstractValidator<FacultyCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public FacultyCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(r => r.Name).NotEmpty().WithMessage(_localizer["FacultyNameCannotBeEmpty"])
                           .NotNull()
                           .MinimumLength(2).WithMessage(_localizer["FacultyNameCannotExceed2Letters"])
                           .MaximumLength(256).WithMessage(_localizer["FacultyNameCannotExceed256Letters"])
                           .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["FacultyNameCanContainLettersAndNumbers"]);
        RuleFor(r=>r.UniversityId).NotEmpty().WithMessage(_localizer["UniversityIdRequired"]);                  
    }
}
