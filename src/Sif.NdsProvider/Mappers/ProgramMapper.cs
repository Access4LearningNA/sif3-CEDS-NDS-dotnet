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
            CreateMap<Program, OrganizationIdentifier>()
                .ForMember(dest => dest.Identifier, map => map.MapFrom(src => src.managingSchoolLocalId.idValue));
               // .ForMember(dest => dest.RefOrganizationIdentifierTypeId, map => map.MapFrom(SchoolLocalId.localIdOrganizationIdentifierTypeId.ToString()));
            CreateMap<Program, FinancialAccount>()
                .ForMember(dest => dest.FinancialExpenditureProjectReportingCode, map => map.MapFrom(src => src.fundingSourceList.Select(x => x.codesetName == MyEnumClass.FinancialExpenditureK12ProjectReportingCode?x.code:null)));
           // CreateMap<Program,>
        }
    }
}
