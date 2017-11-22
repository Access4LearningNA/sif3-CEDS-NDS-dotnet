using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class StaffPersonMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StaffPerson"; }
        }
        public StaffPersonMapper()
        {
            CreateMap<StaffPerson, PersonDetail>()
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.name.nameOfRecord.givenName))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.name.nameOfRecord.familyName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.name.nameOfRecord.middleName))
                .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.name.nameOfRecord.prefix))
                .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.name.nameOfRecord.suffix))
                .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => src.demographics.birthDate))
                .ForMember(dest => dest.HispanicLatinoEthnicity, map => map.MapFrom(src => src.demographics.HispanicLatino));

            CreateMap<StaffPerson, PersonOtherName>()
                .ForMember(Dest => Dest.RefOtherNameTypeId, map => map.MapFrom(src => src.name.nameOfRecord.preferredFamilyName))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.otherNameList.FirstOrDefault().otherName.givenName))
                .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.otherNameList.FirstOrDefault().otherName.middleName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.otherNameList.FirstOrDefault().otherName.familyName));

            CreateMap<StaffPerson, PersonTelephone>()
            .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.FirstOrDefault().number))
            .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.phoneNumberList.FirstOrDefault().phoneNumberType.code));

            CreateMap<StaffPerson, StaffEmployment>()
            .ForMember(dest => dest.PositionTitle, map => map.MapFrom(src => src.title));

            CreateMap<StaffPerson, PersonEmailAddress>()
            .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.emailList.FirstOrDefault().emailType.code));

            CreateMap<StaffPerson, PersonLanguage>()
             .ForMember(dest => dest.RefLanguageUseTypeId, map => map.MapFrom(src => src.demographics.languageList.Any() ? CommonMethods.GetCodesetCode("RefLanguageUseType", "RefLanguageUseTypeId", "Code", src.demographics.languageList.FirstOrDefault().languageType) : "0"));

        }
    }
}
