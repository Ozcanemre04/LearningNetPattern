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
    public class AchievementController : BaseController
    {
         public AchievementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementResponse>>> GetAll()
        {
            var achievements = await _unitOfWork.Achievements.GetAll();
            var achievementDto = achievements.Select(achievement => _mapper.Map<AchievementResponse>(achievement));

            return Ok(achievementDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AchievementResponse>> GetOneById([FromRoute] Guid id)
        {
            var achievement = await _unitOfWork.Achievements.GetById(id);
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
            var achievement = await _unitOfWork.Achievements.GetById(id);
            if (achievement == null)
            {
                return NotFound("achievement is not found");
            }
            await _unitOfWork.Achievements.Delete(achievement);
            await _unitOfWork.completeAsync();
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddAchievementRequest addAchievement)
        {
            var driver = await _unitOfWork.Drivers.GetById(addAchievement.DriverId) ?? null;
            var achievement = _mapper.Map<Achievement>(addAchievement);
            achievement.DriverId = driver.Id;
            await _unitOfWork.Achievements.Add(achievement);
            await _unitOfWork.completeAsync();
            return Ok(true);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateAchievementRequest updateAchievement)
        {
            var achievement = await _unitOfWork.Achievements.GetById(id);
            if (achievement == null)
            {
                return NotFound("achievement is not found");
            }
            _mapper.Map(updateAchievement, achievement);
            await _unitOfWork.Achievements.Update(achievement);
            await _unitOfWork.completeAsync();

            return Ok(true);
        }
    }
}