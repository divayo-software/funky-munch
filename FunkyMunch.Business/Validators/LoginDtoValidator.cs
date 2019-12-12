using FluentValidation;
using FunkyMunch.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Business.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8).MaximumLength(24);
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(16);
        }    
    }
}
