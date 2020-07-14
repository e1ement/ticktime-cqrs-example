using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TickTime.Application.Feature.GetProductList;
using TickTime.Application.Feature.ProductCreate;
using TickTime.Application.Feature.ProductRemove;
using TickTime.Core.Entities;

namespace TickTime.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<ProductItem[]> GetProductList()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpPost("create")]
        public async Task<Guid> CreateProduct(ProductCreate.Command cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpPost("remove")]
        public async Task RemoveProduct(ProductRemove.Command cmd)
        {
            await _mediator.Send(cmd);
        }
    }
}
