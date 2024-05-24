using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class ReviewValidation : AbstractValidator<Review>
    {
        public ReviewValidation()
        {
            RuleFor(x => x.CustomerID)
                .NotEmpty().WithMessage("Customer ID is required");
            RuleFor(x => x.HotelID)
                .NotEmpty().WithMessage("Hotel ID is required");
            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Rating is required");
            RuleFor(x => x.Reviews)
                .NotEmpty().WithMessage("Comment is required")
                .MaximumLength(500).WithMessage("Description is too long");
        }
    }
}
