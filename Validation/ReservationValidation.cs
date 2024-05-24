using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class ReservationValidation : AbstractValidator<Reservation>
    {
        public ReservationValidation()
        {
            RuleFor(x => x.CustomerID).NotEmpty().WithMessage("Customer ID is required");
            RuleFor(x => x.OfertID).NotEmpty().WithMessage("Ofert ID is required");
        }
    }
}
