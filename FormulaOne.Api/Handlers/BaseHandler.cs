using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.DataService.Repository.Interface;

namespace FormulaOne.Api.Handlers
{
    public class BaseHandler
    {
         protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
          _unitOfWork = unitOfWork;
          _mapper = mapper;     
        }
    }
}