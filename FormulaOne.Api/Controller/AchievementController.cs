using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AchievementController : ControllerBase
    {
        private readonly IGenericRepository<Achievement> _achievementRepository;
        private readonly IMapper _mapper;

        public AchievementController(IGenericRepository<Achievement> achievementRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementResponse>>> GetAll()
        {
            var achievements = await _achievementRepository.GetAll();
            var achievementDto = achievements.Select(achievement => _mapper.Map<AchievementResponse>(achievement));

            return Ok(achievementDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AchievementResponse>> GetOneById([FromRoute] Guid id)
        {
            var achievement = await _achievementRepository.GetById(id);
            if (achievement == null)
            {
                return NotFound("achievement not found");
            }
            var achievementDto = _mapper.Map<AchievementResponse>(achievement);

            return Ok(achievementDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOneDriver([FromRoute] Guid id)
        {
            var achievement = await _achievementRepository.GetById(id);
            if (achievement == null)
            {
                return NotFound("achievement not found");
            }
            await _achievementRepository.Delete(achievement);
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddAchievementRequest addAchievement)
        {
            var achievement = _mapper.Map<Achievement>(addAchievement);
            await _achievementRepository.Add(achievement);
            return Ok(true);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateAchievementRequest updateAchievement)
        {
            var achievement = await _achievementRepository.GetById(id);
            if (achievement == null)
            {
                return NotFound("achievement not found");
            }
            _mapper.Map(updateAchievement, achievement);
            await _achievementRepository.Update(achievement);

            return Ok(true);
        }
    }
}