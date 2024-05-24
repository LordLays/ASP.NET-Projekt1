using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validation
{
    public class TagValidation : AbstractValidator<Tag>
    {
        public TagValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required")
                .MaximumLength(100).WithMessage("Description is too long");
        }
    }
}
