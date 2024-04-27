using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.commands.DriversCommands
{
    public class UpdateDriverRequest : IRequest<bool>
    {
        public Guid DriverId { get; }
        public UpdateDriverInfoRequest UpdateDriver { get; }
        public UpdateDriverRequest(Guid driverId , UpdateDriverInfoRequest updateDriver)
        {
            DriverId = driverId;
            UpdateDriver = updateDriver;
        }
    }
}