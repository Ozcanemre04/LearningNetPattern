
using AutoMapper;
using FormulaOne.Api.commands.DriversCommands;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.DriversHandlers
{
    public class CreateDriverHandler : BaseHandler , IRequestHandler<CreateDriverRequest , DriverResponse>
    {
        public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DriverResponse> Handle(CreateDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.AddDriverRequest);
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.completeAsync();
            return _mapper.Map<DriverResponse>(driver);
        }
    }
}