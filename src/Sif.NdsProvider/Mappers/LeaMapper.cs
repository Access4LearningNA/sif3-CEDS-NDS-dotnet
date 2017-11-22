using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class LeaMapper : Profile
    {
        public override string ProfileName
        {
            get { return "LeaMapper"; }
        }
        public LeaMapper()
        {
            CreateMap<Lea, OrganizationDetail>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.leaName))
                .ForMember(dest => dest.ShortName, map => map.MapFrom(src => src.leaName));
            CreateMap<Lea, K12Lea>()
                .ForMember(Dest => Dest.RefLeaTypeId, map => map.MapFrom(src => src.educationAgencyType.FirstOrDefault().ToString() != null ? CommonMethods.GetCodesetCode("refLeaType", "refLeaTypeId", "Code", src.educationAgencyType.FirstOrDefault().ToString()) : null));
            CreateMap<Lea, OrganizationWebsite>()
                .ForMember(dest => dest.Website, map => map.MapFrom(src => src.leaURL));
            CreateMap<Lea, OrganizationTelephone>()
                .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.number + "-" + x.extension).FirstOrDefault()))
                .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.phoneNumberList.Any(x => x.listedStatus.ToString() == "Yes")))
                .ForMember(dest => dest.RefInstitutionTelephoneTypeId, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.phoneNumberType.code.ToString() != null ? CommonMethods.GetCodesetCode("refinstitutiontelephonetype", "RefInstitutionTelephoneTypeId", "Code", x.phoneNumberType.code.ToString()) : null).FirstOrDefault()));
            CreateMap<Lea, PersonDetail>()
                .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => src.leaContactList.Select(x => x.demographics.birthDate).FirstOrDefault()))
                .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.leaContactList.Select(x => x.demographics.birthDateVerification).FirstOrDefault()))
                .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.leaContactList.Select(x => x.demographics.sexus.ToString() != null ? CommonMethods.GetCodesetCode("refsex", "RefSexId", "Code", src.leaContactList.Select(y => y.demographics.sexus.ToString()).FirstOrDefault()) : null)))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.leaContactList.Select(x => x.name.nameOfRecord.familyName).FirstOrDefault()))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.leaContactList.Select(x => x.name.nameOfRecord.givenName).FirstOrDefault()))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.leaContactList.Select(x => x.name.nameOfRecord.middleName).FirstOrDefault()))
                .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.leaContactList.Select(x => x.name.nameOfRecord.prefix).FirstOrDefault()))
                .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.leaContactList.Select(x => x.name.nameOfRecord.suffix).FirstOrDefault()));

            CreateMap<Lea, PersonTelephone>()
                .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.leaContactList.Select(x => x.phoneNumberList.Select(y => y.number + "-" + y.extension)).FirstOrDefault()))
                .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.leaContactList.Select(x => x.phoneNumberList.Any(y => y.listedStatus.ToString() == "Yes")).FirstOrDefault()))
                .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.leaContactList.Select(x => x.phoneNumberList.Select(y => y.phoneNumberType.code.ToString()).FirstOrDefault() != null ? CommonMethods.GetCodesetCode("refpersontelephonenumbertype", "RefPersonTelephoneNumberTypeId", "Code", x.phoneNumberList.Select(y => y.phoneNumberType.code.ToString()).FirstOrDefault()) : null).FirstOrDefault()));
            CreateMap<Lea, PersonEmailAddress>()
                .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.leaContactList.Select(x => x.emailList.Select(y => y.emailAddress)).FirstOrDefault()))
                .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.leaContactList.Select(x => x.emailList.Select(y => y.emailType.code.ToString()) != null ? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", "Code", x.emailList.Select(y => y.emailType.code.ToString()).FirstOrDefault()) : null).FirstOrDefault()));
            CreateMap<Lea, PersonOtherName>()
                .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.leaContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredFamilyName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredFamilyName.ToString()) : null).FirstOrDefault()).FirstOrDefault()))
                .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.leaContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredGivenName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredGivenName.ToString()) : null).FirstOrDefault()).FirstOrDefault()))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.leaContactList.Select(x => x.otherNameList.Select(y => y.otherName.familyName)).FirstOrDefault()))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.leaContactList.Select(x => x.otherNameList.Select(y => y.otherName.givenName)).FirstOrDefault()))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.leaContactList.Select(x => x.otherNameList.Select(y => y.otherName.middleName)).FirstOrDefault()));
            CreateMap<Lea, OrganizationOperationalStatus>()
                .ForMember(dest => dest.RefOperationalStatusId, map => map.MapFrom(src => src.operationalStatus.code.ToString() != null ? CommonMethods.GetCodesetCode("RefOperationalStatus", "RefOperationalStatusId", "Code", src.operationalStatus.code.ToString()) : null));

        }
    }
}
