using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Queries.GetProductList;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.WebAPI.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Shop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :BaseController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery
            {
                Id = 1
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVM>> Get(int id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto create)
        {
            var command = _mapper.Map<CreateProductCommand>(create);
            var saleId = await Mediator.Send(command);
            return Ok(saleId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto update)
        {
            var command = _mapper.Map<UpdateProductCommand>(update);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            await Mediator?.Send(command);
            return NoContent();
        }


    }
}
