
using AutoMapper;
using FormulaOne.Api.Queries.DriversQueries;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.DriversHandlers
{
    public class GetAllDriversHandler : BaseHandler , IRequestHandler<GetAllDriversQuery, IEnumerable<DriverResponse>>
    {
        public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<DriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
           var drivers = await _unitOfWork.Drivers.GetAll();
           return _mapper.Map<IEnumerable<DriverResponse>>(drivers);
            
        }
    }


}