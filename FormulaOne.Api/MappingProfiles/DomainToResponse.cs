using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
         public DomainToResponse()
         {
            CreateMap<Achievement,AchievementResponse>()
            .ForMember(dest => dest.Wins,opt =>opt.MapFrom(src=>src.RaceWins));

            CreateMap<Driver,DriverResponse>();
         }    
    }
}