using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Department;
using BAMyProfileApp.Entities.DbSets;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Department;

public class DepartmentUpdateDTOValidator:AbstractValidator<DepartmentUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public DepartmentUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;
        RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer["DepartmentIdRequired"]).NotNull();
        RuleFor(cp => cp.FacultyId).NotEmpty().WithMessage(_localizer[Messages.FacultyIdRequired]);

        RuleFor(r => r.Name).NotEmpty().WithMessage(_localizer["DepartmentNameCannotBeEmpty"])
                       .NotNull()
                       .MinimumLength(2)
                       .MaximumLength(256).WithMessage(_localizer["DepartmentNameMustBeAtLeast2Characters"])
                       .WithMessage(_localizer["DepartmentNameCannotExceed256Letters"])
                       .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$")
                       .WithMessage(_localizer["DepartmentNameCanContainLettersAndNumbers"]);
    }
}
