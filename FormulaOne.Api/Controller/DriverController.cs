
using AutoMapper;
using FormulaOne.Api.commands.DriversCommands;
using FormulaOne.Api.Queries.DriversQueries;
using FormulaOne.DataService;
using FormulaOne.DataService.Repository;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : BaseController
    {
        public DriverController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverResponse>>> GetAll()
        {
           var query = new GetAllDriversQuery();
           var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<DriverResponse>> GetOneById([FromRoute] Guid id)
        {
            var query = new GetDriverQuery(id);
            var result = await _mediator.Send(query);
            return result == null? NotFound("Not found"): Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOneDriver([FromRoute] Guid id)
        {
            var command  = new DeleteDriverRequest(id);
            var result = await _mediator.Send(command);
            return result == false? NotFound("Not found"): Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddDriverRequest adddriver)
        {
            if(!ModelState.IsValid)
               return BadRequest();

            var command = new CreateDriverRequest(adddriver);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverInfoRequest updatedriver)
        {
            if(!ModelState.IsValid)
               return BadRequest();

            var command  = new UpdateDriverRequest(id,updatedriver);
            var result = await _mediator.Send(command);
            return result == false? NotFound("Not found"): Ok(result);
        }
    }
}