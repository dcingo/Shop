using Microsoft.AspNetCore.Mvc;
using Shop.Application.Buyers.Queries.GetBuyerDetails;
using Shop.Application.Buyers.Queries.GetBuyerList;
using Shop.Application.Buyers.Commands.CreateBuyer;
using Shop.Application.Buyers.Commands.DeleteBuyer;
using Shop.Application.Buyers.Commands.UpdateBuyer;
using Shop.WebAPI.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Shop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : BaseController
    {
        private readonly IMapper _mapper;

        public BuyerController(IMapper mapper)=> _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<BuyerListVm>> GetAll()
        {
            var query = new GetBuyerListQuery
            {
                Id = 1
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerDetailsVM>> Get(int id)
        {
            var query = new GetBuyerDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBuyerDto create)
        {
            var command = _mapper.Map<CreateBuyerCommand>(create);
            var saleId = await Mediator.Send(command);
            return Ok(saleId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBuyerDto update)
        {
           var command = _mapper.Map<UpdateBuyerCommand>(update);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBuyerCommand
            {
                Id = id
            };
            await Mediator?.Send(command);
            return NoContent();
        }


    }
}
