using AutoMapper;
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
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes,OrganizationEmail>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization,OrganizationEmail>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationOperationalStatus>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationOperationalStatus>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationIdentifier>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationIdentifier>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationTelephone>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationTelephone>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationLocation>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationLocation>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonDetail>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, PersonDetail>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonAddress>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, PersonAddress>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonEmailAddress>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, PersonEmailAddress>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonOtherName>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, PersonOtherName>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonTelephone>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, PersonTelephone>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, K12School>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, K12School>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationWebsite>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationWebsite>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationDetail>());
            Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationDetail>());
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationEmail>()
            .ForMember(dest => dest.ElectronicMailAddress, map => map.MapFrom(src => src.emailAddress))
            .ForMember(dest => dest.RefEmailTypeId, map => map.MapFrom(src => src.emailTypeCode.ToString() != null ? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", src.emailTypeCode.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationOperationalStatus>()
            .ForMember(dest => dest.RefOperationalStatusId, map => map.MapFrom(src => src.operationalStatusCode.ToString() != null ? CommonMethods.GetCodesetCode("refoperationalstatus", "RefOperationalStatusId", src.operationalStatusCode.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationIdentifier>()
            .ForMember(dest=>dest.Identifier,map=>map.MapFrom(src=>src.localIdIdvalue))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationTelephone>()
            .ForMember(dest => dest.TelephoneNumber, map => map.MapFrom(src => src.phoneNumber))
            .ForMember(dest => dest.PrimaryTelephoneNumberIndicator, map => map.MapFrom(src => src.phoneNumberExtension))
            .ForMember(dest => dest.RefInstitutionTelephoneTypeId, map => map.MapFrom(src => src.phoneNumberTypeCode.ToString() != null ? CommonMethods.GetCodesetCode("refinstitutiontelephonetype", "RefInstitutionTelephoneTypeId", src.phoneNumberTypeCode.ToString()) : null))
            );

            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationLocation>()
            .ForMember(dest=>dest.RefOrganizationLocationTypeId,map=>map.MapFrom(src=>src.schoolContactAddressRole.ToString() !=null ? CommonMethods.GetCodesetCode("reforganizationlocationtype", "RefOrganizationLocationTypeId", src.schoolContactAddressRole.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonDetail>()
            .ForMember(dest=>dest.Birthdate,map=>map.MapFrom(src=>src.schoolContactBirthdate))
            .ForMember(dest=>dest.BirthdateVerification,map=>map.MapFrom(src=>src.schoolContactBirthdateverification))
            .ForMember(dest=>dest.RefSexId,map=>map.MapFrom(src=>src.schoolContactSexus.ToString()!=null? CommonMethods.GetCodesetCode("refsex", "RefSexId", src.schoolContactSexus.ToString()) : null))
            .ForMember(dest=>dest.LastName,map=>map.MapFrom(src=>src.schoolContactFamilyname))
            .ForMember(dest=>dest.FirstName,map=>map.MapFrom(src=>src.schoolContactGivenname))
            .ForMember(dest=>dest.MiddleName,map=>map.MapFrom(src=>src.schoolContactMiddlename))
            .ForMember(dest=>dest.Prefix,map=>map.MapFrom(src=>src.schoolContactPrefix))
            .ForMember(dest=>dest.GenerationCode,map=>map.MapFrom(src=>src.schoolContactSuffix))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonAddress>()
            .ForMember(dest=>dest.RefCountryId,map=>map.MapFrom(src=>src.schoolContactcountryOfResidencyCode.ToString() !=null? CommonMethods.GetCodesetCode("reforganizationlocationtype", "RefCountryId", src.schoolContactAddressRole.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonEmailAddress>()
            .ForMember(dest=>dest.EmailAddress,map=>map.MapFrom(src=>src.schoolContactEmailaddress))
            .ForMember(dest=>dest.RefEmailTypeId,map=>map.MapFrom(src=>src.schoolContactEmailTypeCode.ToString() !=null? CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", src.schoolContactEmailTypeCode.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonOtherName>()
            .ForMember(dest=>dest.RefOtherNameTypeId,map=>map.MapFrom(src=>src.schoolContactOtherNameFamilyname.ToString() !=null? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", src.schoolContactOtherNameFamilyname.ToString()) : null))
            .ForMember(dest => dest.RefOtherNameTypeId, map => map.MapFrom(src => src.schoolContactOtherNameGivenname.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", src.schoolContactOtherNameGivenname.ToString()) : null))
            .ForMember(dest=>dest.LastName,map=>map.MapFrom(src=>src.schoolContactOtherNameFamilyname))
            .ForMember(dest=>dest.FirstName,map=>map.MapFrom(src=>src.schoolContactOtherNameGivenname))
            .ForMember(dest=>dest.MiddleName,map=>map.MapFrom(src=>src.schoolContactOtherNameMiddlename))
            .ForMember(dest=>dest.RefOtherNameTypeId,map=>map.MapFrom(src=>src.schoolContactOtherNamePreferredfamilyname.ToString()!=null? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", src.schoolContactOtherNamePreferredfamilyname.ToString()) : null))
            .ForMember(dest=>dest.RefOtherNameTypeId,map=>map.MapFrom(src=>src.schoolContactOtherNamePreferredgivenname.ToString() != null ? CommonMethods.GetCodesetCode("refothernametype", "RefOtherNameTypeId", src.schoolContactOtherNamePreferredgivenname.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, PersonTelephone>()
            .ForMember(dest=>dest.TelephoneNumber,map=>map.MapFrom(src=>src.schoolContactphoneNumber))
            .ForMember(dest=>dest.PrimaryTelephoneNumberIndicator,map=>map.MapFrom(src=>src.schoolContactphoneNumberExtension))
            .ForMember(dest=>dest.RefPersonTelephoneNumberTypeId,map=>map.MapFrom(src=>src.schoolContactphoneNumberTypeCode.ToString() != null ? CommonMethods.GetCodesetCode("refpersontelephonenumbertype", "RefPersonTelephoneNumberTypeId", src.schoolContactphoneNumberTypeCode.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, K12School>()
            .ForMember(dest=>dest.RefSchoolTypeId,map=>map.MapFrom(src=>src.schoolFocus.ToString() !=null ? CommonMethods.GetCodesetCode("refschooltype", "RefSchoolTypeId", src.schoolFocus.ToString()) : null))
            .ForMember(dest=>dest.CharterSchoolIndicator,map=>map.MapFrom(src=>src.schoolSector))
            .ForMember(dest=>dest.RefSchoolLevelId,map=>map.MapFrom(src=>src.schoolTypeCode.ToString() !=null ? CommonMethods.GetCodesetCode("refschoollevel", "RefSchoolLevelId", src.schoolTypeCode.ToString()) : null))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationWebsite>()
            .ForMember(dest=>dest.Website,map=>map.MapFrom(src => src.schoolURL))
            );
            Mapper.Initialize(cfg => cfg.CreateMap<SchoolAttributes, OrganizationDetail>()
            .ForMember(dest=>dest.Name,map=>map.MapFrom(src => src.schoolName))
            .ForMember(dest=>dest.ShortName,map=>map.MapFrom(src => src.schoolName))
            );

        }
       
    }
}
