using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.DriversQueries
{
    public class GetDriverQuery : IRequest<DriverResponse>
    {
        public Guid DriverId { get; }
        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
            
        }
    }
}