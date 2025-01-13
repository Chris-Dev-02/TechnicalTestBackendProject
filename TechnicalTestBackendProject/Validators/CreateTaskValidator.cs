using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class CreateTaskValidator : AbstractValidator<TaskCreateDTO>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .Length(6, 300)
                .WithMessage("Description must be between 6 and 300 characters");
            RuleFor(x => x.TaskState)
                .NotEmpty()
                .WithMessage("Task State is required");
        }
    }
}
