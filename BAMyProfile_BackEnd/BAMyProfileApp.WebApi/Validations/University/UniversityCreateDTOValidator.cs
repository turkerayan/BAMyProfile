﻿using AutoMapper;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.University;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.University;

public class UniversityCreateDTOValidator : AbstractValidator<UniversityCreateDTO>
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public UniversityCreateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;

        RuleFor(r => r.Name).NotEmpty()
                            .WithMessage(_localizer["UniversityNameCannotBeEmpty"])
                            .NotNull()
                            .MinimumLength(2).WithMessage(_localizer["UniversityNamecannotbelessthan2letters"])
                            .MaximumLength(256).WithMessage(_localizer["UniversityNameCannotExceed256Letters"])
                            .WithMessage(_localizer["UniversityNameCannotExceed256Letters"])
                            .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(_localizer["UniversityNameCanContainLettersAndNumbers"]);
    }
}
