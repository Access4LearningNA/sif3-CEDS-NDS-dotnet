﻿using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class StudentMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StudentMapper"; }
        }
        public StudentMapper()
        {
            CreateMap<Student, PersonAddress>()
            .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.stateProvinceId != null ? CommonMethods.GetCodesetCode("RefState", "RefStateId", "Code", src.stateProvinceId) : null));

            CreateMap<Student, PersonBirthplace>()
                .ForMember(Dest => Dest.City, map => map.MapFrom(src => src.demographics.placeOfBirth))
             .ForMember(dest => dest.RefCountryId, map => map.MapFrom(src => src.demographics.countryOfBirth.code != null ? CommonMethods.GetCodesetCode("RefCountry", "RefCountryId", "Code", src.demographics.countryOfBirth.code) : null))
             .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.demographics.stateProvinceOfBirth.code != null ? CommonMethods.GetCodesetCode("RefState", "RefStateId", "Code", src.demographics.stateProvinceOfBirth.code) : null));

            CreateMap<Student, PersonDetail>()
            .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => Convert.ToDateTime(src.demographics.birthDate).ToShortDateString()))
            .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.demographics.birthDateVerification))
            .ForMember(dest => dest.HispanicLatinoEthnicity, map => map.MapFrom(src => src.demographics.HispanicLatino))
            .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.demographics.sex.ToString() != null ? CommonMethods.GetCodesetCode("RefSex", "RefSexId", "Code", src.demographics.sex.ToString()=="M"?"Male":"Female") : null))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.name.nameOfRecord.familyName))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.name.nameOfRecord.givenName))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.name.nameOfRecord.middleName))
            .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.name.nameOfRecord.prefix))
            .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.name.nameOfRecord.suffix));
           
            CreateMap<Student, PersonDisability>()
            .ForMember(dest => dest.PrimaryDisabilityTypeId, map => map.MapFrom(src =>  src.disability.primaryDisability.code != null ? CommonMethods.GetCodesetCode("RefDisabilityType", "RefDisabilityTypeId", "Code", src.disability.primaryDisability.code) : null))
            .ForMember(dest => dest.DisabilityStatus, map => map.MapFrom(src => src.disability.Status));

            CreateMap<Student, PersonEmailAddress>()
            .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.emailList.Any() ? src.emailList.FirstOrDefault().emailAddress : null))
            .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.emailList.Any() ? CommonMethods.GetCodesetCode("RefEmailType", "RefEmailTypeId", "Code", src.emailList.FirstOrDefault().emailType.code) : null));

            CreateMap<Student, PersonLanguage>()
                .ForMember(dest => dest.RefLanguageId, map => map.MapFrom(src => src.demographics.languageList.Any() ? CommonMethods.GetCodesetCode("RefLanguage", "RefLanguageId", "Code", src.demographics.languageList.FirstOrDefault().languageCode.code) : null))
             .ForMember(dest => dest.RefLanguageUseTypeId, map => map.MapFrom(src => src.demographics.languageList.Any() ? CommonMethods.GetCodesetCode("RefLanguageUseType", "RefLanguageUseTypeId", "Code", src.demographics.languageList.FirstOrDefault().languageType) : "0"));

            CreateMap<Student, PersonOtherName>()
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.name.nameOfRecord.preferredFamilyName) : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.name.nameOfRecord.preferredGivenName) : null))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.familyName : null))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.middleName : null))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.givenName : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.otherNameList.FirstOrDefault().otherName.preferredFamilyName) : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", "Code", src.otherNameList.FirstOrDefault().otherName.preferredGivenName) : null));

            CreateMap<Student, PersonTelephone>()
            .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Any() ? src.phoneNumberList.FirstOrDefault().number+"-"+ src.phoneNumberList.FirstOrDefault().extension : null))
            .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.phoneNumberList.Any(y => y.listedStatus.ToString() == "Yes")))
            .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.phoneNumberList.Any() ? CommonMethods.GetCodesetCode("RefPersonTelephoneNumberType", "RefPersonTelephoneNumberTypeId", "Code", src.phoneNumberList.FirstOrDefault().phoneNumberType.code) : null));
            
            CreateMap<Student, ProgramParticipationTitleI>()
           .ForMember(dest => dest.RefTitleIIndicatorId, map => map.MapFrom(src => src.title1 != null ? CommonMethods.GetCodesetCode("RefTitleIIndicator", "RefTitleIIndicatorId", "Code", src.title1.ToString()) : null));

            CreateMap<Student, ProgramParticipationSpecialEducation>()
               .ForMember(dest => dest.AwaitingInitialIDEAEvaluationStatus, map => map.MapFrom(src => src.disability.awaitingInitialIDEAEvaluation.ToString().Any(x => x.ToString() == "Yes")))
               .ForMember(dest => dest.RefIDEAEdEnvironmentSchoolAgeId, map => map.MapFrom(src => src.disability.ideaEnvironment.code != null ? CommonMethods.GetCodesetCode("RefIDEAEducationalEnvironmentSchoolAge", "RefIDEAEducationalEnvironmentSchoolAgeId", "Code", src.disability.ideaEnvironment.code) : null))
               .ForMember(dest => dest.RefIDEAEducationalEnvironmentECId, map => map.MapFrom(src => src.disability.ideaIndicator.ToString() != null ? CommonMethods.GetCodesetCode("RefIDEAEducationalEnvironmentEC", "RefIDEAEducationalEnvironmentECId", "Code", src.disability.ideaIndicator.ToString()) : null));
           
            CreateMap<Student, K12StudentAcademicRecord>()
                .ForMember(dest => dest.ProjectedGraduationDate, map => map.MapFrom(src => src.projectedGraduationYear));
            CreateMap<Student, K12StudentCohort>()
                .ForMember(dest => dest.CohortGraduationYear, map => map.MapFrom(src => src.onTimeGraduationYear));
        }
    }
}
