using FluentValidation;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Validators
{
    public class UpdateTaskValidator : AbstractValidator<TaskUpdateDTO>
    {
        public UpdateTaskValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required")
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");
            RuleFor(x => x.TaskState)
                .NotEmpty()
                .WithMessage("Task State is required");
        }
    }
}
