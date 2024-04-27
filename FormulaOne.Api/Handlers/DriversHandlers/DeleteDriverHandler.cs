using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.commands.DriversCommands;
using FormulaOne.DataService.Repository.Interface;
using MediatR;

namespace FormulaOne.Api.Handlers.DriversHandlers
{
    public class DeleteDriverHandler : BaseHandler, IRequestHandler<DeleteDriverRequest, bool>
    {
        public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(DeleteDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
            if (driver == null)
            {
                return false;
            }
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.completeAsync();
            return true;
        }
    }
}