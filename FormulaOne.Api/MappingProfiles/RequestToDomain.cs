
using AutoMapper;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;


namespace FormulaOne.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
       public RequestToDomain()
       {
         // addachievement map
          CreateMap<AddAchievementRequest,Achievement>()
          .ForMember(dest => dest.RaceWins,opt => opt.MapFrom(src => src.Wins))
          .ForMember(dest => dest.Status,opt => opt.MapFrom(src => 1))
          .ForMember(dest => dest.AddedDate,opt => opt.MapFrom(src => DateTime.Now))
          .ForMember(dest => dest.UpdatedDate,opt => opt.MapFrom(src => DateTime.Now));

          // updateAchievement map
          CreateMap<UpdateAchievementRequest,Achievement>()
          .ForMember(dest => dest.RaceWins,opt => opt.MapFrom(src => src.Wins))
          .ForMember(dest => dest.UpdatedDate,opt => opt.MapFrom(src => DateTime.Now))
          .ForAllMembers(opts => opts.Condition((src,dest,srcMember)=> srcMember != null));

          // add Driver map
          CreateMap<AddDriverRequest,Driver>()
          .ForMember(dest => dest.Status,opt=> opt.MapFrom(src => 1))
          .ForMember(dest => dest.AddedDate,opt => opt.MapFrom(src => DateTime.Now))
          .ForMember(dest => dest.UpdatedDate,opt => opt.MapFrom(src => DateTime.Now));

          //update driver map
          CreateMap<UpdateDriverInfoRequest,Driver>()
          .ForMember(dest => dest.UpdatedDate,opt => opt.MapFrom(src => DateTime.Now))
          .ForAllMembers(opts => opts.Condition((src,dest,srcMember)=> srcMember != null));
       }   
    }
}