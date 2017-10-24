using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System.Linq;
namespace Sif.NdsProvider.Mappers
{
    public class SchoolCalendarItemMapper : Profile
    {
        public SchoolCalendarItemMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolCalendarItem, CourseSectionSchedule>()
           .ForMember(dest => dest.TimeDayIdentifier, map => map.MapFrom(src => src.bellScheduleDayList.Any() ? src.bellScheduleDayList.FirstOrDefault().timetableDayIdentifier : null)));

            Mapper.Initialize(cfg => cfg.CreateMap<SchoolCalendarItem, OrganizationCalendarEvent>()
           .ForMember(dest => dest.RefCalendarEventType, map => map.MapFrom(src => src.@event))
           .ForMember(dest => dest.EventDate, map => map.MapFrom(src => src.eventDayName))
           );

        }
    }
}
