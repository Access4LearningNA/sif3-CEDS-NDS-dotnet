using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;
namespace Sif.NdsProvider.Mappers
{
    public class SeaMapper : Profile
    {
        public override string ProfileName
        {
            get { return "SeaMapper"; }
        }
        public SeaMapper()
        {
            CreateMap<Sea,OrganizationDetail>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.seaName))
                .ForMember(dest => dest.ShortName, map => map.MapFrom(src => src.seaName));
            CreateMap<Sea, OrganizationWebsite>()
                .ForMember(dest => dest.Website, map => map.MapFrom(src => src.seaURL));
            CreateMap<Sea, OrganizationTelephone>()
                .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.number + "-" + x.extension).FirstOrDefault()))
                .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.phoneNumberList.Any(x => x.listedStatus.ToString() == "Yes")))
                .ForMember(dest => dest.RefInstitutionTelephoneTypeId, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.phoneNumberType.code.ToString() != null ? CommonMethods.GetCodesetCode("refinstitutiontelephonetype", "RefInstitutionTelephoneTypeId", "Code", x.phoneNumberType.code.ToString()) : null).FirstOrDefault()));
            CreateMap<Sea, PersonDetail>()
                .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => src.seaContactList.Select(x => x.demographics.birthDate).FirstOrDefault()))
                .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.seaContactList.Select(x => x.demographics.birthDateVerification).FirstOrDefault()))
                .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.seaContactList.Select(x => x.demographics.sexus.ToString() != null ? CommonMethods.GetCodesetCode("refsex", "RefSexId", "Code", src.seaContactList.Select(y => y.demographics.sexus.ToString()).FirstOrDefault()) : null)))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.seaContactList.Select(x => x.name.nameOfRecord.familyName).FirstOrDefault()))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.seaContactList.Select(x => x.name.nameOfRecord.givenName).FirstOrDefault()))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.seaContactList.Select(x => x.name.nameOfRecord.middleName).FirstOrDefault()))
                .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.seaContactList.Select(x => x.name.nameOfRecord.prefix).FirstOrDefault()))
                .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.seaContactList.Select(x => x.name.nameOfRecord.suffix).FirstOrDefault()));
            CreateMap<Sea, PersonAddress>()
                .ForMember(dest => dest.RefCountryId, map => map.MapFrom(src => src.seaContactList.Select(x => x.demographics.countryOfResidency.code.ToString() != null ? CommonMethods.GetCodesetCode("refCountry", "RefCountryId", "Code", src.seaContactList.Select(y => y.demographics.countryOfResidency.code.ToString()).FirstOrDefault()) : null)));

            CreateMap<Sea, PersonTelephone>()
                .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.seaContactList.Select(x => x.phoneNumberList.Select(y => y.number + "-" + y.extension)).FirstOrDefault()))
                .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.seaContactList.Select(x => x.phoneNumberList.Any(y => y.listedStatus.ToString() == "Yes"))))
                .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.seaContactList.Select(x => x.phoneNumberList.Select(y => y.phoneNumberType.code.ToString()) != null ? CommonMethods.GetCodesetCode("refpersontelephonenumbertype", "RefPersonTelephoneNumberTypeId", "Code", x.phoneNumberList.Select(y => y.phoneNumberType.code.ToString()).FirstOrDefault()) : null)));
            CreateMap<Sea, PersonEmailAddress>()
                .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.seaContactList.Select(x => x.emailList.Select(y => y.emailAddress)).FirstOrDefault()))
                .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.seaContactList.Select(x => x.emailList.Select(y => y.emailType.code.ToString()) != null ? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", "Code", x.emailList.Select(y => y.emailType.code.ToString()).FirstOrDefault()) : null)));
            CreateMap<Sea, PersonOtherName>()
                .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.seaContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredFamilyName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredFamilyName.ToString()) : null))))
                .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.seaContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredGivenName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredGivenName.ToString()) : null))))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.seaContactList.Select(x => x.otherNameList.Select(y => y.otherName.familyName)).FirstOrDefault()))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.seaContactList.Select(x => x.otherNameList.Select(y => y.otherName.givenName)).FirstOrDefault()))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.seaContactList.Select(x => x.otherNameList.Select(y => y.otherName.middleName)).FirstOrDefault()));
           
        }
    }
}
