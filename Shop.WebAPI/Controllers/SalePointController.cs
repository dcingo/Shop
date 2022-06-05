using Microsoft.AspNetCore.Mvc;
using Shop.Application.SalePoints.Queries.GetSalePointDetails;
using Shop.Application.SalePoints.Queries.GetSalePointList;
using Shop.Application.SalePoints.Commands.CreateSalePoint;
using Shop.Application.SalePoints.Commands.DeleteSalePoint;
using Shop.Application.SalePoints.Commands.UpdateSalePoint;
using Shop.WebAPI.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;


namespace Shop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalePointController : BaseController
    {

        private readonly IMapper _mapper;

        public SalePointController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<SalePointListVm>> GetAll()
        {
            var query = new GetSalePointsListQuery
            {
                Id = 1
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SalePointDetailsVm>> Get(int id)
        {
            var query = new GetSalePointDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSalePointsDto create)
        {
            var command = _mapper.Map<CreateSalePointCommands>(create);
            var saleId = await Mediator.Send(command);
            return Ok(saleId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBuyerDto update)
        {
            var command = _mapper.Map<UpdateSalePointCommand>(update);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DaeleteSalePointCommand
            {
                Id = id
            };
            await Mediator?.Send(command);
            return NoContent();
        }




    }
}
