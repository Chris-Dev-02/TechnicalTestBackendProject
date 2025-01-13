using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class SignupValidator : AbstractValidator<UserCreateDTO>
    {
        public SignupValidator() 
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");
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
