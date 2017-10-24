using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class SchoolCalendarMapper: Profile
    {
        public SchoolCalendarMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolCalendar, OrganizationCalendar>()
            .ForMember(dest => dest.CalendarDescription, map => map.MapFrom(src => src.description))
            .ForMember(dest => dest.CalendarCode, map => map.MapFrom(src => src.localId.idType.code))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolCalendar, OrganizationCalendarSession>()
           .ForMember(dest => dest.LastInstructionDate, map => map.MapFrom(src => src.lastInstructionDate))
           .ForMember(dest => dest.FirstInstructionDate, map => map.MapFrom(src => src.firstInstructionDate))
           .ForMember(dest => dest.DaysInSession, map => map.MapFrom(src => src.daysInSession))
           .ForMember(dest => dest.InstructionalMinutes, map => map.MapFrom(src => src.instructionalMinutes))
           .ForMember(dest => dest.MarkingTermIndicator, map => map.MapFrom(src => src.markingTermIndicator))           
           .ForMember(dest => dest.SchedulingTermIndicator, map => map.MapFrom(src => src.sessionSchedulingTermIndicator))
           );
        }
    }
}
