using AutoMapper;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
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
           
            CreateMap<StudentProgramAssociation, ELEnrollment>()
            .ForMember(dest => dest.EnrollmentDate, map => map.MapFrom(s => s.entryDate));
            CreateMap<StudentProgramAssociation, K12StudentEnrollment>()
           .ForMember(dest => dest.RefEntryType, map => map.MapFrom(s => s.entryType.code))
           .ForMember(dest => dest.RefExitOrWithdrawalStatusId, map => map.MapFrom(s => s.exitStatus.code))
           .ForMember(dest => dest.RefExitOrWithdrawalTypeId, map => map.MapFrom(s => s.exitType.code))
           .ForMember(dest => dest.RefPublicSchoolResidence, map => map.MapFrom(s => s.residencyStatus));//need to change when change the FK columnName as RefPublicSchoolResidenceId
            //.ForMember(dest => dest/*No Mapping*/, map => map.MapFrom(s => s.schoolYear))
           
        }
    }

}


