using AutoMapper;
using Program=Sif.NdsProvider.Model.Program;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;

namespace Sif.NdsProvider.Mappers
{
    public class ProgramMapper:Profile
    {
        public override string ProfileName
        {
            get { return "ProgramMapper"; }
        }
        public ProgramMapper()
        {

            //CreateMap<Program, FinancialAccount>()
            //    .ForMember(dest => dest.FinancialExpenditureProjectReportingCode, map => map.MapFrom(src => src.fundingSourceList.Select(x => x.codesetName == MyEnumClass.FinancialExpenditureK12ProjectReportingCode ? x.code : null)))
            //    .ForMember(dest => dest.Name, map => map.MapFrom(src => src.fundingSourceList.Select(x => x.codesetName.ToString())));
            CreateMap<Program, OrganizationDetail>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.programName.ToString()))
                .ForMember(dest => dest.ShortName, map => map.MapFrom(src => src.programName.ToString()))
                .ForMember(dest => dest.RecordStartDateTime, map => map.MapFrom(src => DateTime.Now));
            CreateMap<Program, OrganizationProgramType>()
                .ForMember(dest => dest.RefProgramTypeId, map => map.MapFrom(src => src.programType1.ToString() != null ? CommonMethods.GetCodesetCode("refProgramType", "RefProgramTypeId", "Description", src.programType1.ToString()) : null))
                .ForMember(dest => dest.RecordStartDateTime, map => map.MapFrom(src => DateTime.Now));
           
        }
    }
}
