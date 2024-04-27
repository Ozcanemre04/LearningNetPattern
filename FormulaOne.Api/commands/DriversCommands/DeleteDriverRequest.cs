using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FormulaOne.Api.commands.DriversCommands
{
    public class DeleteDriverRequest : IRequest<bool>
    {
        public Guid DriverId { get; }
        
        public DeleteDriverRequest(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}