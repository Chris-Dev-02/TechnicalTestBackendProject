using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
