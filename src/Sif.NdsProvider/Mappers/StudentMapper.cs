﻿using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Mapper.Initialize(cfg => cfg.CreateMap<Student, K12StudentAcademicRecord>()
            .ForMember(dest => dest.ProjectedGraduationDate, map => map.MapFrom(src => src.projectedGraduationYear))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, K12StudentCohort>()
            .ForMember(dest => dest.CohortGraduationYear, map => map.MapFrom(src => src.onTimeGraduationYear))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonAddress>()
            .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.stateProvinceId != null ? CommonMethods.GetCodesetCode("RefState", "RefStateId", src.stateProvinceId) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonBirthplace>()
            .ForMember(dest => dest.RefCountryId, map => map.MapFrom(src => src.demographics.countryOfBirth.code != null ? CommonMethods.GetCodesetCode("RefCountry", "RefCountryId", src.demographics.countryOfBirth.code) : null))
            .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.demographics.stateProvinceOfBirth.code != null ? CommonMethods.GetCodesetCode("RefState", "RefStateId", src.demographics.stateProvinceOfBirth.code) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonDetail>()
            .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => src.demographics.birthDate))
            .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.demographics.birthDateVerification))
            .ForMember(dest => dest.HispanicLatinoEthnicity, map => map.MapFrom(src => src.demographics.ethnicityList.Any() ? src.demographics.ethnicityList.FirstOrDefault().code : null))
            .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.demographics.sex.ToString() != null ? CommonMethods.GetCodesetCode("RefSex", "RefSexId", src.demographics.sex.ToString()) : null))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.name.nameOfRecord.familyName))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.name.nameOfRecord.fullName))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.name.nameOfRecord.middleName))
            .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.name.nameOfRecord.prefix))
            .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.name.nameOfRecord.suffix))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonDisability>()
            .ForMember(dest => dest.PrimaryDisabilityTypeId, map => map.MapFrom(src => src.disability.primaryDisability.code != null ? CommonMethods.GetCodesetCode("RefDisabilityType", "RefDisabilityTypeId", src.disability.primaryDisability.code) : null))
            .ForMember(dest => dest.DisabilityStatus, map => map.MapFrom(src => src.disability.Status))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonEmailAddress>()
            .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.emailList.Any() ? src.emailList.FirstOrDefault().emailAddress : null))
            .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.emailList.Any() ? CommonMethods.GetCodesetCode("RefEmailType", "RefEmailTypeId", src.emailList.FirstOrDefault().emailType.code) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonLanguage>()
            .ForMember(dest => dest.RefLanguageUseTypeId, map => map.MapFrom(src => src.demographics.languageList.Any() ? CommonMethods.GetCodesetCode("RefLanguageUseType", "RefLanguageUseTypeId", src.demographics.languageList.FirstOrDefault().languageType) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonOtherName>()
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.emailList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", src.name.nameOfRecord.preferredFamilyName) : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.emailList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", src.name.nameOfRecord.preferredGivenName) : null))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.familyName : null))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.middleName : null))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.otherNameList.Any() ? src.otherNameList.FirstOrDefault().otherName.givenName : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", src.otherNameList.FirstOrDefault().otherName.preferredFamilyName) : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.otherNameList.Any() ? CommonMethods.GetCodesetCode("RefOtherNameType", "RefOtherNameTypeId", src.otherNameList.FirstOrDefault().otherName.preferredGivenName) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, PersonTelephone>()
            .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Any() ? src.phoneNumberList.FirstOrDefault().number : null))
            .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.phoneNumberList.Any() ? CommonMethods.GetCodesetCode("RefPersonTelephoneNumberType", "RefPersonTelephoneNumberTypeId", src.phoneNumberList.FirstOrDefault().phoneNumberType.code) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, ProgramParticipationSpecialEducation>()
            .ForMember(dest => dest.AwaitingInitialIDEAEvaluationStatus, map => map.MapFrom(src => src.disability.awaitingInitialIDEAEvaluation))
            .ForMember(dest => dest.RefIDEAEdEnvironmentSchoolAgeId, map => map.MapFrom(src => src.disability.ideaEnvironment.code != null ? CommonMethods.GetCodesetCode("RefIDEAEducationalEnvironmentSchoolAge", "RefIDEAEducationalEnvironmentSchoolAgeId", src.disability.ideaEnvironment.code) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, ProgramParticipationTitleI>()
            .ForMember(dest => dest.RefTitleIIndicatorId, map => map.MapFrom(src => src.title1 != null ? CommonMethods.GetCodesetCode("RefTitleIIndicator", "RefTitleIIndicatorId", src.title1.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<Student, RefISO6393Language>()
            .ForMember(dest => dest.Code, map => map.MapFrom(src => src.demographics.languageList.Any() ? src.demographics.languageList.FirstOrDefault().dialect : null))
            .ForMember(dest => dest.Code, map => map.MapFrom(src => src.demographics.languageList.Any() ? src.demographics.languageList.FirstOrDefault().languageCode.code : null))
            );
        }
    }
}
