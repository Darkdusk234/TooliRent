using FluentValidation;
using TooliRent.Services.DTOs.ToolDtos;

namespace TooliRent.Services.Validators.ToolValidators
{
    public class UpdateToolDtoValidator : AbstractValidator<UpdateToolDto>
    {
        public UpdateToolDtoValidator()
        {
            RuleFor(t => t.ToolType)
                .NotEmpty().WithMessage("Tool name is required.")
                .MaximumLength(100).WithMessage("Tool name cannot exceed 100 characters.")
                .MinimumLength(2).WithMessage("Tool name must be at least 2 characters long.");

            RuleFor(t => t.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(t => t.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
        }
    }
}
