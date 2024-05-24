using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class OffertValidation : AbstractValidator<Offert>
    {
        public OffertValidation()
        {
            RuleFor(x => x.HotelID)
                .NotEmpty().WithMessage("Hotel ID is required");
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required");
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required");
            RuleFor(x => x.TakeOffPlace)
                .NotEmpty().WithMessage("Take off place is required")
                .MaximumLength(100).WithMessage("Take off place is too long");
            RuleFor(x => x.AvailableSeats)
                .NotEmpty().WithMessage("Available seats is required");
            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Meal)
                .NotEmpty().WithMessage("Meal is required");
            RuleFor(x => x.TripType)
                .NotEmpty().WithMessage("Trip type is required");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description is too long");
        }
    }
}
