﻿using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Event;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Validations.Event;

public class EventUpdateDTOValidator : AbstractValidator<EventUpdateDTO>
{
    private readonly IStringLocalizer<MessageResources> localizer;

    public EventUpdateDTOValidator(IStringLocalizer<MessageResources> localizer)
    {
        this.localizer = localizer;
       RuleFor(dto => dto.Id).NotEmpty().WithMessage(localizer[Messages.EventIdRequired]).NotNull();

                RuleFor(r => r.Title).NotEmpty().WithMessage(localizer[Messages.EventNameCanNotBeEmpty])
                     .NotNull()
                     .MinimumLength(2).WithMessage(localizer[Messages.EventNameMustBeAtLeast2Characters])
                     .MaximumLength(50).WithMessage(localizer[Messages.EventNameCanNotExceed50Characters])
                     .Matches(@"^[a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+$").WithMessage(localizer[Messages.EventNameCanContainLettersAndNumbers]);

        RuleFor(r => r.Date).NotNull()
                            .NotEmpty().WithMessage(localizer[Messages.EventDateCanNotBeEmpty])
                            .GreaterThanOrEqualTo(DateTime.Now);

        RuleFor(r => r.EventType).NotNull()
                                 .NotEmpty().WithMessage(localizer[Messages.EventTypeCanNotBeEmpty])
                                 .IsInEnum();
        
    }
}