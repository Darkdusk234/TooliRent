using FluentValidation;
using TooliRent.Services.DTOs.BookingDtos;

namespace TooliRent.Services.Validators.BookingValidators
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingDtoValidator()
        {
            RuleFor(b => b.ToolId)
                .GreaterThan(0).WithMessage("Valid tool must be selected.");

            RuleFor(b => b.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(b => b.LastBookedDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddDays(1)).WithMessage("Booked date must be in the future.");
        }
    }
}
