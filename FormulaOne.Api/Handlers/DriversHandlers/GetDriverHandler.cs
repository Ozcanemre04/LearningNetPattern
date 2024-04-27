

using AutoMapper;
using FormulaOne.Api.Queries.DriversQueries;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.DriversHandlers
{
    public class GetDriverHandler : BaseHandler , IRequestHandler<GetDriverQuery, DriverResponse>
    {
        public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {

            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
            return driver == null? null: _mapper.Map<DriverResponse>(driver);
        }
    }
}