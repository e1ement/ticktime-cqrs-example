using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TickTime.Application.Feature.GetProductList;
using TickTime.Application.Feature.ProductCreate;
using TickTime.Application.Feature.ProductRemove;
using TickTime.Core.Entities;

namespace TickTime.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        [MapToApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task<ProductItem[]> GetProductList()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpGet("list")]
        [MapToApiVersion("2")]
        [ApiExplorerSettings(GroupName = "v2")]
        public async Task<ProductItem[]> GetProductListV2()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        /// <summary>
        /// Create productItem
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item Id</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [MapToApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task<Guid> CreateProduct(ProductCreate.Command cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpPost("remove")]
        [MapToApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task RemoveProduct(ProductRemove.Command cmd)
        {
            await _mediator.Send(cmd);
        }
    }
}
