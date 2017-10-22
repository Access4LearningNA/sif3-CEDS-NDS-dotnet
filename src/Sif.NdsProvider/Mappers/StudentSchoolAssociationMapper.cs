using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;

namespace Sif.NdsProvider.Mappers
{
    public class StudentSchoolAssociationMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StudentSchoolAssociationMapper"; }
        }
        public StudentSchoolAssociationMapper()
        {
            var createdBy = "SIFAdmin";
            var statusId = "1";
            Random ran = new Random();
            Mapper.Initialize(cfg => cfg.CreateMap<StudentSchoolAssociation, ELEnrollment>()
            .ForMember(dest => dest.EnrollmentDate, map => map.MapFrom(s => s.entryDate)));
            Mapper.Initialize(cfg => cfg.CreateMap<StudentSchoolAssociation, K12StudentEnrollment>()
           .ForMember(dest => dest.RefEntryType, map => map.MapFrom(s => s.entryType.code))
           //.ForMember(dest => dest/*No Mapping*/, map => map.MapFrom(s => s.exitDate))
           .ForMember(dest => dest.RefExitOrWithdrawalStatusId, map => map.MapFrom(s => s.exitStatus.code))
           .ForMember(dest => dest.RefExitOrWithdrawalTypeId, map => map.MapFrom(s => s.exitType.code))
           .ForMember(dest => dest.RefPublicSchoolResidence, map => map.MapFrom(s => s.residencyStatus))
           .ForMember(dest => dest.RefPublicSchoolResidence, map => map.MapFrom(s => s.residencyStatus))
           //.ForMember(dest => dest/*No Mapping*/, map => map.MapFrom(s => s.schoolYear))
           );
        }
    }

}


