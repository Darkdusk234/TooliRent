using FluentValidation;
using TooliRent.Services.DTOs.AuthDtos;

namespace TooliRent.Services.Validators.AuthValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(r => r.BirthDate)
                .LessThan(DateTime.UtcNow).WithMessage("Birth date must be in the past.")
                .GreaterThan(DateTime.UtcNow.AddYears(-15)).WithMessage("You must be older than 15 to register")
                .GreaterThan(DateTime.UtcNow.AddYears(-120)).WithMessage("Birth date is not valid.");
        }
    }
}
