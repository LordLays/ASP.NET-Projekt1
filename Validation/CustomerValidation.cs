using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Invalid email address")
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(150).WithMessage("Max Length is 100");
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MaximumLength(20).WithMessage("Max Length is 20");

        }
    }
}
