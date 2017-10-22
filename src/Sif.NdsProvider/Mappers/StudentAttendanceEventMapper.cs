using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class StudentAttendanceEventMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StudentAttendanceEventMapper"; }
        }
        public StudentAttendanceEventMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StudentAttendanceEvent, CourseSectionSchedule>()
            .ForMember(dest => dest.ClassPeriod, map => map.MapFrom(src => src.timeTablePeriod))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<StudentAttendanceEvent, RoleAttendanceEvent>()
            .ForMember(dest => dest.RefAbsentAttendanceCategoryId, map => map.MapFrom(src => src.absentAttendanceCategory != null ? (src.absentAttendanceCategory.code != null ? (CommonMethods.GetCodesetCode("RefAbsentAttendanceCategory", "RefAbsentAttendanceCategoryId", src.absentAttendanceCategory.code)) : null) : null))
            .ForMember(dest => dest.RefAttendanceEventTypeId, map => map.MapFrom(src => CommonMethods.GetCodesetCode("RefAttendanceEventType", "RefAttendanceEventTypeId", src.attendanceEventType.ToString())))
            .ForMember(dest => dest.RefAttendanceStatusId, map => map.MapFrom(src => src.attendanceStatus != null ? (src.attendanceStatus.code != null ? (CommonMethods.GetCodesetCode("RefAttendanceStatus", "RefAttendanceStatusId", src.attendanceStatus.code)) : null) : null))
            );
        }
    }
}
