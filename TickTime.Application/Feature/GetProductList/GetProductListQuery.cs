using MediatR;
using TickTime.Core.Entities;

namespace TickTime.Application.Feature.GetProductList
{
    public class GetProductListQuery : IRequest<ProductItem[]>
    {
    }
}
