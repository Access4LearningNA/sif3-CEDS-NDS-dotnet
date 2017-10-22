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
            Mapper.Initialize(cfg => cfg.CreateMap<School, SchoolAttributes>()
           .ForMember(dest => dest.CreatedBy, map => map.MapFrom(s => createdBy))
           .ForMember(dest => dest.CreateDateTime, map => map.MapFrom(s => DateTime.Now))

            );
        }
    }
}
