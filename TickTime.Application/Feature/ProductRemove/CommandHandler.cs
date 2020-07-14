using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TickTime.Application.Services;
using TickTime.Core.Entities;

namespace TickTime.Application.Feature.ProductRemove
{
    public partial class ProductRemove
    {
        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly Repository _repository;

            public CommandHandler(Repository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.RemoveAsync<ProductItem>(request.Id);

                return Unit.Value;
            }
        }
    }
}
