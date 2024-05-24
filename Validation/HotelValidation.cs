using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class HotelValidation : AbstractValidator<Hotel>
    {
        public HotelValidation()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(h => h.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(255).WithMessage("Max Length is 255");
            RuleFor(h => h.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(h => h.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(h => h.StarRating)
                .InclusiveBetween(1, 5).WithMessage("Stars must be between 1 and 5");
        }
    }
}
