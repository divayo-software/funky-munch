using FluentValidation;
using FunkyMunch.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Business.Validators
{
    public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationDtoValidator()
        {
            RuleFor(x => x.EmailAddress).EmailAddress().MaximumLength(128);
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8).MaximumLength(24);
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(16);
        }
    }
}
