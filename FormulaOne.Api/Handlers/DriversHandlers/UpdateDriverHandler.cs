
using AutoMapper;
using FormulaOne.Api.commands.DriversCommands;
using FormulaOne.DataService.Repository.Interface;
using MediatR;

namespace FormulaOne.Api.Handlers.DriversHandlers
{
    public class UpdateDriverHandler : BaseHandler, IRequestHandler<UpdateDriverRequest, bool>
    {
        public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(UpdateDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
            if (driver == null)
            {
                return false;
            }
            _mapper.Map(request.UpdateDriver, driver);
            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.completeAsync();
            return true;
        }
    }
}