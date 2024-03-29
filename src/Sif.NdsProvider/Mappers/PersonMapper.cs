﻿using AutoMapper;
using Person= Sif.NdsProvider.Model.Person;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;

namespace Sif.NdsProvider.Mappers
{
    public class PersonMapper : Profile
    {
        public override string ProfileName
        {
            get { return "PersonMapper"; }
        }
        public PersonMapper()
        {
            CreateMap<Person, PersonDetail>()
               .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => Convert.ToDateTime(src.demographics.birthDate).ToShortDateString()))
               .ForMember(dest => dest.HispanicLatinoEthnicity, map => map.MapFrom(src => src.demographics.HispanicLatino))
               .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.demographics.birthDateVerification))
           
               .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.demographics.sex.ToString() != null ? CommonMethods.GetCodesetCode("RefSex", "RefSexId", "Code", src.demographics.sex.ToString()) : null))
               .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.name.nameOfRecord.familyName))
               .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.name.nameOfRecord.givenName))
               .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.name.nameOfRecord.middleName))
               .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.name.nameOfRecord.prefix))
               .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.name.nameOfRecord.suffix));
            CreateMap<Person, PersonOtherName>()
           .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.name.nameOfRecord.preferredFamilyName) : null))
           .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.name.nameOfRecord.preferredGivenName) : null))
           .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.familyName : null))
           .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.middleName : null))
           .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.givenName : null))
           .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.otherNameList.FirstOrDefault().otherName.preferredFamilyName) : null))
           .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.otherNameList.FirstOrDefault().otherName.preferredGivenName) : null));
            CreateMap<Person, PersonLanguage>()
               .ForMember(dest => dest.RefLanguageUseTypeId, map => map.MapFrom(src => src.demographics.languageList.Any() ? CommonMethods.GetCodesetCode("RefLanguageUseType", "RefLanguageUseTypeId", "Code", src.demographics.languageList.FirstOrDefault().languageType) : "0"));
            CreateMap<Person,PersonStatus>()
                .ForMember(dest => dest.RefPersonStatusTypeId, map => map.MapFrom(src => src.demographics.languageProficiency.ToString().ToLower() == "yes" ? CommonMethods.GetCodesetCode("RefPersonstatustype", "RefPersonStatusTypeId", "Code", MyEnumClass.LEPStatus) : null));
            CreateMap<Person,PersonBirthplace>()
                .ForMember(dest=>dest.City,map=>map.MapFrom(src=>src.demographics.placeOfBirth))
                 .ForMember(dest => dest.RefCountryId, map => map.MapFrom(src => src.demographics.countryOfBirth.code != null ? CommonMethods.GetCodesetCode("RefCountry", "RefCountryId", "Code", src.demographics.countryOfBirth.code) : null))
                .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.demographics.stateProvinceOfBirth.code != null ? CommonMethods.GetCodesetCode("RefState", "RefStateId", "Code", src.demographics.stateProvinceOfBirth.code) : null));
            CreateMap<Person, PersonEmailAddress>()
               .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.emailList.Any() ? src.emailList.FirstOrDefault().emailAddress : null))
               .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.emailList.Any() ? CommonMethods.GetCodesetCode("RefEmailType", "RefEmailTypeId", "Code", src.emailList.FirstOrDefault().emailType.code) : null));
            CreateMap<Person, PersonTelephone>()
             .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Any() ? src.phoneNumberList.FirstOrDefault().number + "-" + src.phoneNumberList.FirstOrDefault().extension : null))
             .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.phoneNumberList.Any(y => y.listedStatus.ToString() == "Yes")))
             .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.phoneNumberList.Any() ? CommonMethods.GetCodesetCode("RefPersonTelephoneNumberType", "RefPersonTelephoneNumberTypeId", "Code", src.phoneNumberList.FirstOrDefault().phoneNumberType.code) : null));




        }
    }
}
