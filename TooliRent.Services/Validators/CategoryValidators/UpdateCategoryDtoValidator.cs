using FluentValidation;
using TooliRent.Services.DTOs.CategoryDtos;

namespace TooliRent.Services.Validators.CategoryValidators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.")
                .MinimumLength(2).WithMessage("Category name must be at least 2 characters long.");

            RuleFor(c => c.Description)
                .MaximumLength(255).WithMessage("Category description must not exceed 255 characters.");
        }
    }
}
