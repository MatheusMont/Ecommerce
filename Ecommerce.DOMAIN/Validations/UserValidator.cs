using Ecommerce.DOMAIN.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("{PropertyName} must be included");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} must be included")
                .EmailAddress()
                .WithMessage("{PropertyName} must be a valid email");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} must be included")
                .MinimumLength(8)
                .WithMessage("{PropertyName} must have a minimum of 8 characters")
                .MaximumLength(100)
                .WithMessage("{PropertyName} must have a maximum of 100 characters")
                .Must(ValidatePassword)
                .WithMessage("{PropertyName} must contain an upper case letter, a lower case letter, a number and a symbol [#, ?, !, @, $, %, ^, &, *, -]");

        }

        protected bool ValidatePassword(string password)
        {
            var validator = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*0-9)(?=.*?[#?!@$%^&*-])");

            if (!validator.IsMatch(password)) return false;

            return true;
        }
    }
}
