using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;

namespace Sif.NdsProvider.Mappers
{
    public class StudentProgramAssociationsMapper:Profile
    {
        public override string ProfileName
        {
            get { return "StudentSchoolAssociationMapper"; }
        }
        public StudentProgramAssociationsMapper()
        {
            var createdBy = "SIFAdmin";
            var statusId = "1";
            Random ran = new Random();
            Mapper.Initialize(cfg => cfg.CreateMap<StudentSchoolAssociation, K12StudentEnrollment>()
           .ForMember(dest => dest/*No Mapping*/, map => map.MapFrom(s => s.entryDate))
           .ForMember(dest => dest.RefEntryType, map => map.MapFrom(s => s.entryType.code))
           .ForMember(dest => dest/*No Mapping*/, map => map.MapFrom(s => s.exitDate)));
        }
    }
}
