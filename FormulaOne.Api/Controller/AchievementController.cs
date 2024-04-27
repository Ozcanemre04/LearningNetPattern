using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.commands.AchievementCommands;
using FormulaOne.Api.Queries.AchievementsQueries;
using FormulaOne.DataService;
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
    public class AchievementController : BaseController
    {
         public AchievementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementResponse>>> GetAll()
        {
            var query = new GetAllAchievementsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AchievementResponse>> GetOneById([FromRoute] Guid id)
        {
           var query = new GetAchievementQuery(id);
           var result = await _mediator.Send(query);
           return result == null? NotFound("Not found"): Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOneDriver([FromRoute] Guid id)
        {
           var query = new DeleteAchievementCommand(id);
           var result = await _mediator.Send(query);
           return result == false? NotFound("Not found"): Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddAchievementRequest addAchievement)
        {
            if(!ModelState.IsValid)
               return BadRequest();
           var query = new CreateAchievementCommand(addAchievement);
           var result = await _mediator.Send(query);
           return Ok(result); 
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateAchievementRequest updateAchievement)
        {
            if(!ModelState.IsValid)
               return BadRequest();
           var query = new UpdateAchievementCommand(id, updateAchievement);
           var result = await _mediator.Send(query);
           return result == false? NotFound("Not found"): Ok(result);
        }
    }
}