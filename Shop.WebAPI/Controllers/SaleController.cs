using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sales.Queries.GetSaleDetails;
using Shop.Application.Sales.Queries.GetSaleList;
using Shop.Application.Sales.Commands.CreateSale;
using Shop.Application.Sales.Commands.DeleteSale;
using Shop.Application.Sales.Commands.UpdateSale;
using Shop.WebAPI.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Shop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : BaseController
    {
        private readonly IMapper _mapper;

        public SaleController(IMapper mapper)=> _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<SaleListVm>> GetAll()
        {
            var query = new GetSaleListQuery
            {
                Id = 1
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDetailsVM>> Get(int id)
        {
            var query = new GetSaleDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSaleDto createSaleDto)
        {
            var command = _mapper.Map<CreateSaleCommand>(createSaleDto);
            var saleId = await Mediator.Send(command);
            return Ok(saleId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSaleDto updateSaleDto)
        {
           var command = _mapper.Map<UpdateSaleCommand>(updateSaleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSaleCommand
            {
                Id = id
            };
            await Mediator?.Send(command);
            return NoContent();
        }


    }
}
