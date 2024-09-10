using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Experience;
using FluentValidation;
using Microsoft.Extensions.Localization; 
using System;

namespace BAMyProfileApp.WebApi.Validations.Experience
{
    public class ExperienceUpdateDTOValidator : AbstractValidator<ExperienceUpdateDTO>
    {
        private readonly IStringLocalizer<MessageResources> _localizer; 

        public ExperienceUpdateDTOValidator(IStringLocalizer<MessageResources> localizer) 
        {
            _localizer = localizer;

            RuleFor(dto => dto.Id).NotEmpty().WithMessage(_localizer["ExperienceIdNotEmpty"]);

            RuleFor(dto => dto.CompanyName)
                .NotEmpty().WithMessage(_localizer["Company_Name_Not_Empty"])
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100).WithMessage(_localizer["Company_Name_Max_Length"])
                .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["CompanyNameFormat"]);

            RuleFor(dto => dto.DateOfStart)
                .NotNull()
                .NotEmpty().WithMessage(_localizer["DateOfStartNotEmpty"])
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(dto => dto.DateOfEnd)
                .Must((dto, dateOfEnd) => dateOfEnd == null || dateOfEnd >= dto.DateOfStart)
                .WithMessage(_localizer["DateOfEndMustBeAfterStart"]);

            RuleFor(dto => dto.Position)
                .NotEmpty().WithMessage(_localizer["PositionNotEmpty"])
                .NotNull()
                .MaximumLength(50).WithMessage(_localizer["PositionMaxLength"]);

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage(_localizer["DescriptionNotEmpty"])
                .NotNull();

            RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(_localizer[Messages.StudentIdRequired])
            .NotNull();
        }
    }
}
