using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.DataService.Repository;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : BaseController
    {
        public DriverController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverResponse>>> GetAll()
        {
            var drivers = await _unitOfWork.Drivers.GetAll();
            var driversDto = drivers.Select(driver => _mapper.Map<DriverResponse>(driver));

            return Ok(driversDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<DriverResponse>> GetOneById([FromRoute] Guid id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound("driver not found");
            }
            var driverDto = _mapper.Map<DriverResponse>(driver);

            return Ok(driverDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOneDriver([FromRoute] Guid id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound("driver not found");
            }
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.completeAsync();
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddDriverRequest adddriver)
        {
            var driver = _mapper.Map<Driver>(adddriver);
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.completeAsync();
            return Ok(true);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverRequest updatedriver)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound("driver not found");
            }
            _mapper.Map(updatedriver, driver);
            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.completeAsync();

            return Ok(true);
        }
    }
}