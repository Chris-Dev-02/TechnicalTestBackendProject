using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class CreateBoardValidator : AbstractValidator<BoardCreateDTO>
    {
        public CreateBoardValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Length(3, 50)
                .WithMessage("Name must be between 3 and 50 characters");
        }
    }
}
