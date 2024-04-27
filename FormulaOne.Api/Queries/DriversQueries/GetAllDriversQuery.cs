using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.DriversQueries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<DriverResponse>>
    {}
}