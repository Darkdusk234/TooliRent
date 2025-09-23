using FluentValidation;
using TooliRent.Services.DTOs.BookingDtos;

namespace TooliRent.Services.Validators.BookingValidators
{
    public class UpdateBookingDtoValidator : AbstractValidator<UpdateBookingDto>
    {
        public UpdateBookingDtoValidator()
        {
            RuleFor(b => b.ToolId)
                .NotEmpty().WithMessage("At least one tool must be selected.")
                .Must(toolIds => toolIds.All(id => id > 0)).WithMessage("All selected tools must be valid.")
                .Must(toolIds => toolIds.Distinct().Count() == toolIds.Count).WithMessage("Duplicate tools are not allowed.");

            RuleFor(b => b.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(b => b.StartBookedDate)
               .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Start booked date must be today or in the future.")
               .LessThan(b => b.LastBookedDate);

            RuleFor(b => b.LastBookedDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddDays(1)).WithMessage("Booked date must be in the future.");
        }
    }
}
