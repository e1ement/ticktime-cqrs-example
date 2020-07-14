using FluentValidation;

namespace TickTime.Application.Feature.ProductCreate
{
    public class Validator : AbstractValidator<ProductCreate.Command>
    {
        public Validator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
