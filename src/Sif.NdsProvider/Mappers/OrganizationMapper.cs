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
    public class OrganizationMapper : Profile
    {
        public override string ProfileName
        {
            get { return "OrganizationMapper"; }
        }
        public OrganizationMapper()
        {
           
            CreateMap<School, OrganizationDetail>()
               .ForMember(dest => dest.Name, map => map.MapFrom(src => src.schoolName))
               .ForMember(dest => dest.ShortName, map => map.MapFrom(src => src.schoolName));
            CreateMap<School, OrganizationTelephone>()
               .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.number+"-"+ x.extension).FirstOrDefault()))
               .ForMember(dest=>dest.PrimaryTelephoneNumberIndicator,map=>map.MapFrom(src=>src.phoneNumberList.Any(x=>x.listedStatus.ToString()=="Yes")))
               .ForMember(dest => dest.RefInstitutionTelephoneTypeId, map => map.MapFrom(src => src.phoneNumberList.Select(x => x.phoneNumberType.code.ToString() != null ? CommonMethods.GetCodesetCode("refinstitutiontelephonetype", "RefInstitutionTelephoneTypeId","Code", x.phoneNumberType.code.ToString()) : null).FirstOrDefault()));
            CreateMap<School, OrganizationEmail>()
               .ForMember(dest => dest.ElectronicMailAddress, map => map.MapFrom(src => src.emailList.Select(x => x.emailAddress).FirstOrDefault()))
               .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.emailList.Select(x => x.emailType.code.ToString() != null ? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", "Code", x.emailType.code.ToString()) : null).FirstOrDefault()));
            CreateMap<School, OrganizationOperationalStatus>()
               .ForMember(dest => dest.RefOperationalStatusId, map => map.MapFrom(src => src.operationalStatus.code.ToString() != null ? CommonMethods.GetCodesetCode("refoperationalstatus", "RefOperationalStatusId", "Code", src.operationalStatus.code.ToString()) : null));
            CreateMap<School, K12School>()
               .ForMember(dest => dest.RefSchoolTypeId, map => map.MapFrom(src => src.schoolType.code.ToString() != null ? CommonMethods.GetCodesetCode("refschooltype", "RefSchoolTypeId", "Code", src.schoolType.code.ToString()) : null))
                .ForMember(dest => dest.CharterSchoolIndicator, map => map.MapFrom(src => src.schoolSector.ToString() == "School" || src.schoolSector.ToString() == "CollegeUniversity"|| src.schoolSector.ToString() == "NA" ? 1:0))
                .ForMember(dest=>dest.RefAdministrativeFundingControlId,map=>map.MapFrom(src=>src.schoolFocusList.FirstOrDefault() !=null ?CommonMethods.GetCodesetCode("RefAdministrativeFundingControl", "RefAdministrativeFundingControlId", "Code", src.schoolFocusList.FirstOrDefault()):null))
               .ForMember(dest => dest.RefSchoolLevelId, map => map.MapFrom(src => src.schoolType.code.ToString() != null ? CommonMethods.GetCodesetCode("refschoollevel", "RefSchoolLevelId", "Code", src.schoolType.code.ToString()) : null));
            CreateMap<School, OrganizationWebsite>()
               .ForMember(dest => dest.Website, map => map.MapFrom(src => src.schoolURL));
           
            CreateMap<School, PersonDetail>()
            .ForMember(dest => dest.Birthdate, map => map.MapFrom(src => src.schoolContactList.Select(x => x.demographics.birthDate).FirstOrDefault()))
            .ForMember(dest => dest.BirthdateVerification, map => map.MapFrom(src => src.schoolContactList.Select(x => x.demographics.birthDateVerification).FirstOrDefault()))
            .ForMember(dest => dest.RefSexId, map => map.MapFrom(src => src.schoolContactList.Select(x => x.demographics.sexus.ToString() != null ? CommonMethods.GetCodesetCode("refsex", "RefSexId", "Code", src.schoolContactList.Select(y => y.demographics.sexus.ToString()).FirstOrDefault()) : null)))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.name.nameOfRecord.familyName).FirstOrDefault()))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.name.nameOfRecord.givenName).FirstOrDefault()))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.name.nameOfRecord.middleName).FirstOrDefault()))
            .ForMember(dest => dest.Prefix, map => map.MapFrom(src => src.schoolContactList.Select(x => x.name.nameOfRecord.prefix).FirstOrDefault()))
            .ForMember(dest => dest.GenerationCode, map => map.MapFrom(src => src.schoolContactList.Select(x => x.name.nameOfRecord.suffix).FirstOrDefault()));
            CreateMap<School, PersonAddress>()
            .ForMember(dest => dest.RefCountryId, map => map.MapFrom(src => src.schoolContactList.Select(x => x.demographics.countryOfResidency.code.ToString() != null ? CommonMethods.GetCodesetCode("refCountry", "RefCountryId", "Code", src.schoolContactList.Select(y => y.demographics.countryOfResidency.code.ToString()).FirstOrDefault()) : null)));

            CreateMap<School, PersonTelephone>()
            .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.schoolContactList.Select(x=>x.phoneNumberList.Select(y=>y.number+"-"+y.extension)).FirstOrDefault()))
            .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.schoolContactList.Select(x=>x.phoneNumberList.Any(y=>y.listedStatus.ToString()=="Yes"))))
            .ForMember(dest => dest.RefPersonTelephoneNumberTypeId, map => map.MapFrom(src => src.schoolContactList.Select(x=>x.phoneNumberList.Select(y=>y.phoneNumberType.code.ToString()) != null ? CommonMethods.GetCodesetCode("refpersontelephonenumbertype", "RefPersonTelephoneNumberTypeId", "Code", x.phoneNumberList.Select(y => y.phoneNumberType.code.ToString()).FirstOrDefault()) : null)));
            CreateMap<School, PersonEmailAddress>()
            .ForMember(dest => dest.EmailAddress, map => map.MapFrom(src => src.schoolContactList.Select(x => x.emailList.Select(y => y.emailAddress)).FirstOrDefault()))
            .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.schoolContactList.Select(x => x.emailList.Select(y => y.emailType.code.ToString()) != null ? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", "Code", x.emailList.Select(y => y.emailType.code.ToString()).FirstOrDefault()) : null)));
           CreateMap<School, PersonOtherName>()
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.schoolContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredFamilyName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredFamilyName.ToString()) : null))))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.schoolContactList.Select(x => x.otherNameList.Select(y => y.otherName.preferredGivenName.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", "Code", y.otherName.preferredGivenName.ToString()) : null))))
            .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.otherNameList.Select(y => y.otherName.familyName)).FirstOrDefault()))
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.otherNameList.Select(y => y.otherName.givenName)).FirstOrDefault()))
            .ForMember(dest => dest.MiddleName, map => map.MapFrom(src => src.schoolContactList.Select(x => x.otherNameList.Select(y => y.otherName.middleName)).FirstOrDefault()));
            //Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationLocation>()
            //.ForMember(dest=>dest.RefOrganizationLocationTypeId,map=>map.MapFrom(src=>src.schoolContactAddressRole.ToString() !=null ? CommonMethods.GetCodesetCode("reforganizationlocationtype", "RefOrganizationLocationTypeId", src.schoolContactAddressRole.ToString()) : null))
            //);

        }

    }
}
