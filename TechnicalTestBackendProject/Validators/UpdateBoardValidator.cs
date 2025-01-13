using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class UpdateBoardValidator : AbstractValidator<BoardUpdateDTO>
    {
        public UpdateBoardValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required")
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0");
        }
    }
}
