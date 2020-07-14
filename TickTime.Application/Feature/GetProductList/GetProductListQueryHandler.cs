using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TickTime.Application.Services;
using TickTime.Core.Entities;

namespace TickTime.Application.Feature.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductItem[]>
    {
        private readonly Repository _repository;

        public GetProductListQueryHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<ProductItem[]> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.FindAsync<ProductItem>();

            return items.ToArray();
        }
    }
}
