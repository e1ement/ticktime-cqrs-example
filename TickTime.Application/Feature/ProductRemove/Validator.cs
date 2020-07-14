using FluentValidation;
using System;

namespace TickTime.Application.Feature.ProductRemove
{
    public class Validator : AbstractValidator<ProductRemove.Command>
    {
        public Validator()
        {
            RuleFor(s => s.Id).Must((id) => id != Guid.Empty);
        }
    }
}
