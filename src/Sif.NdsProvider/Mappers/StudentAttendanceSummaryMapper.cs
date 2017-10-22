using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Mappers
{
    public class StudentAttendanceSummaryMapper : Profile
    {
        public override string ProfileName
        {
            get { return "SchoolAttributesMapper"; }
        }
        public StudentAttendanceSummaryMapper()
        {
            var createdBy = "SIFAdmin";
            var statusId = "1";
            Random ran = new Random();
            Mapper.Initialize(cfg => cfg.CreateMap<StudentAttendanceSummarys, RoleAttendance>()
            .ForMember(dest => dest.AttendanceRate, map => map.MapFrom(s => s.counts.First().rate)));
            Mapper.Initialize(cfg => cfg.CreateMap<StudentAttendanceSummarys, K12StudentEnrollment>()
            .ForMember(dest => dest.RefPublicSchoolResidence, map => map.MapFrom(s => s.resident))
            );
        }
    }
}
