using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class HotelRoomValidation : AbstractValidator<HotelRoom>
    {
        public HotelRoomValidation()
        {
            RuleFor(x => x.HotelID)
                .NotEmpty().WithMessage("Hotel ID is required");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Room number is required");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Room type is required");
            RuleFor(x => x.Capacity)
                .NotEmpty().WithMessage("Room capacity is required");
            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Description is too long");
        }
    }
}
