using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.DataService.Repository.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
          _mediator = mediator;
        }
    }
}