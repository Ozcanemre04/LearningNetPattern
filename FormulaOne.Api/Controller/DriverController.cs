using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {

        private readonly IGenericRepository<Driver> _driverRepository;
        private readonly IMapper _mapper;

        public DriverController(IGenericRepository<Driver> driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverResponse>>> GetAll()
        {
            var drivers = await _driverRepository.GetAll();
            var driversDto = drivers.Select(driver => _mapper.Map<DriverResponse>(driver));

            return Ok(driversDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<DriverResponse>> GetOneById([FromRoute] Guid id)
        {
            var driver = await _driverRepository.GetById(id);
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
            var driver = await _driverRepository.GetById(id);
            if (driver == null)
            {
                return NotFound("driver not found");
            }
            await _driverRepository.Delete(driver);
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddDriverRequest adddriver)
        {
            var driver = _mapper.Map<Driver>(adddriver);
            await _driverRepository.Add(driver);
            return Ok(true);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverRequest updatedriver)
        {
            var driver = await _driverRepository.GetById(id);
            if (driver == null)
            {
                return NotFound("driver not found");
            }
            _mapper.Map(updatedriver, driver);
            await _driverRepository.Update(driver);

            return Ok(true);
        }

    }
}