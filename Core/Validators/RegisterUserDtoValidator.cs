using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Поле пошта є обов'язковим!")
                .EmailAddress().WithMessage("Пошта є не коректною!");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Password")
                .WithMessage("Поле пароль є обов'язковим!")
                .MinimumLength(8)
                .WithName("Password")
                .WithMessage("Поле пароль має містити міннімум 5 символів!")
                .Must(el=> ValidationMethods.IsHaveDigit(el))
                .WithName("Password")
                .WithMessage("Поле пароль повинно містити цифру")
                .Must(el => ValidationMethods.IsHaveUpperCase(el))
                .WithName("Password")
                .WithMessage("Поле пароль має містити хоч би одну велику літеру")
                .Must(el => ValidationMethods.IsHaveLowerCase(el))
                .WithName("Password")
                .WithMessage("Поле пароль має містити хоч би одну маленьку літеру")
                ;
            //RuleFor(x => x.ConfirmPassword)
            //    .NotEmpty()
            //    .WithName("ConfirmPassword")
            //    .WithMessage("Поле є обов'язковим!")
            //    .Equal(x => x.Password).WithMessage("Поролі не співпадають!");
        }

    }
}
