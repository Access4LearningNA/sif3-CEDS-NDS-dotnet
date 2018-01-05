using AutoMapper;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
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
            //CreateMap<StudentProgramAssociation, K12StudentEnrollment>()
            //   .ForMember(dest => dest.RefEntryType, map => map.MapFrom(s => s.entryType.code))
            //   .ForMember(dest => dest.RefExitOrWithdrawalStatusId, map => map.MapFrom(s => s.exitStatus.code))
            //   .ForMember(dest => dest.RefExitOrWithdrawalTypeId, map => map.MapFrom(s => s.exitType.code));
            CreateMap<StudentProgramAssociation, OrganizationPersonRole>()
                  .ForMember(dest => dest.EntryDate, map => map.MapFrom(src => src.entryDate))
                  .ForMember(dest => dest.ExitDate, map => map.MapFrom(src => src.exitDate));
            CreateMap<StudentProgramAssociation, PersonProgramParticipation>()
                  .ForMember(dest => dest.RefParticipationTypeId, map => map.MapFrom(src => src.entryType.code.ToString() != null ? CommonMethods.GetCodesetCode("RefParticipationType", "RefParticipationTypeId", "Code", src.entryType.code.ToString()):null))
                  .ForMember(dest => dest.RefProgramExitReasonId, map => map.MapFrom(src => src.entryType.code.ToString() != null ? CommonMethods.GetCodesetCode("RefProgramExitReason", "RefProgramExitReasonId", "Code", src.entryType.code.ToString()) : null));

        }
    }
}
