using MediatR;
using System;

namespace TickTime.Application.Feature.ProductRemove
{
    public partial class ProductRemove
    {
        public class Command : IRequest
        {
            public Guid Id { get; }

            public Command(Guid id)
            {
                Id = id;
            }
        }
    }
}
