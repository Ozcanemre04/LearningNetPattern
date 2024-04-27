using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.commands.DriversCommands
{
    public class CreateDriverRequest : IRequest<DriverResponse>
    {
        public AddDriverRequest AddDriverRequest { get; }
        public CreateDriverRequest(AddDriverRequest addDriverRequest)
        {
            AddDriverRequest = addDriverRequest;
        }
    }
}