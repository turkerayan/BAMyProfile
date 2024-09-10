using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Department;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Department;

public class DepartmentCreateDTOValidator:AbstractValidator<DepartmentCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public DepartmentCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(cp => cp.FacultyId).NotEmpty().WithMessage(_localizer[Messages.FacultyIdRequired]);

        RuleFor(r => r.Name).NotEmpty().WithMessage(_localizer["DepartmentNameCannotBeEmpty"])
                       .NotNull()
                       .MinimumLength(2).WithMessage(_localizer["DepartmentNameMustBeAtLeast2Characters"])
                       .MaximumLength(256).WithMessage(_localizer["DepartmentNameCannotExceed256Letters"])
                       .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["DepartmentNameCanContainLettersAndNumbers"]);

        
    }
}



