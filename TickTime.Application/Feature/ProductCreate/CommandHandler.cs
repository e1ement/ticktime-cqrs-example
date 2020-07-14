using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TickTime.Application.Services;
using TickTime.Core.Entities;

namespace TickTime.Application.Feature.ProductCreate
{
    public partial class ProductCreate
    {
        public class CommandHandler : IRequestHandler<Command, Guid>
        {
            private readonly Repository _repository;

            public CommandHandler(Repository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = new ProductItem(Guid.NewGuid(), request.Name);

                await _repository.CreateAsync(product);

                return product.Id;
            }
        }
    }
}
