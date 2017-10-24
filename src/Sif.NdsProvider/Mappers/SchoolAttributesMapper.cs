using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Mappers
{
    public class SchoolAttributesMapper : Profile
    {
        public override string ProfileName
        {
            get { return "SchoolAttributesMapper"; }
        }
       public SchoolAttributesMapper()
        {
            var  createdBy = "SIFAdmin";
            var statusId = "1";
            Random ran = new Random();
            Mapper.Initialize(cfg => cfg.CreateMap<School, SchoolAttributes>()
            .ForMember(dest => dest.SchoolRefId, map => map.MapFrom(s => s.refId))
            .ForMember(dest=>dest.emailAddress,map=>map.MapFrom(s=>s.emailList.Select(x=>x.emailAddress)))
            .ForMember(dest=>dest.emailTypeCode,map=>map.MapFrom(s=> s.emailList.Select(x => x.emailType)))
             .ForMember(dest => dest.externalIdTypeCode, map => map.MapFrom(s => s.externalIdList.Select(x => x.idType.code)))
             .ForMember(dest => dest.idTypeCode, map => map.MapFrom(s => s.localId.idType.code))
             .ForMember(dest=>dest.localIdIdvalue,map=>map.MapFrom(s=>s.localId.idValue))
             .ForMember(dest => dest.operationalStatusCode, map => map.MapFrom(s => s.operationalStatus.code))
             .ForMember(dest => dest.phoneNumberExtension, map => map.MapFrom(s => s.phoneNumberList.Select(x => x.extension)))
             .ForMember(dest => dest.phoneNumber, map => map.MapFrom(s => s.phoneNumberList.Select(x => x.number)))
             .ForMember(dest => dest.phoneNumberTypeCode, map => map.MapFrom(s => s.phoneNumberList.Select(x => x.phoneNumberType.code)))
             .ForMember(dest => dest.schoolContactAddressRole, map => map.MapFrom(s => s.schoolContactList.Select(x => x.addressRefIdList.Select(q => q.addressRole))))
             .ForMember(dest => dest.schoolContactBirthdate, map => map.MapFrom(s => s.schoolContactList.Select(x => x.demographics.birthDate)))
              .ForMember(dest => dest.schoolContactBirthdateverification, map => map.MapFrom(s => s.schoolContactList.Select(x => x.demographics.birthDateVerification)))
            .ForMember(dest => dest.schoolContactcountryOfResidencyCode, map => map.MapFrom(s => s.schoolContactList.Select(x => x.demographics.countryOfResidency.code)))
            .ForMember(dest => dest.schoolContactSexus, map => map.MapFrom(s => s.schoolContactList.Select(x => x.demographics.sexus)))
            .ForMember(dest => dest.schoolContactElectronicIdValue, map => map.MapFrom(s => s.schoolContactList.Select(x => x.electronicIdList.Select(z => z.idValue))))
            .ForMember(dest => dest.schoolContactEmailaddress, map => map.MapFrom(s => s.schoolContactList.Select(x => x.emailList.Select(z => z.emailAddress))))
           .ForMember(dest => dest.schoolContactEmailTypeCode, map => map.MapFrom(s => s.schoolContactList.Select(x => x.emailList.Select(z => z.emailType.code))))
            .ForMember(dest => dest.schoolContactExternalIdTypeCode, map => map.MapFrom(s => s.schoolContactList.Select(x => x.externalId.idType.code)))
            .ForMember(dest => dest.schoolContactExternalIdvalue, map => map.MapFrom(s => s.schoolContactList.Select(x => x.externalId.idValue)))
             .ForMember(dest => dest.schoolContactLocalIdTypeCode, map => map.MapFrom(s => s.schoolContactList.Select(x => x.localId.idType.code)))
            .ForMember(dest => dest.schoolContactLocalIdValue, map => map.MapFrom(s => s.schoolContactList.Select(x => x.localId.idValue)))
             .ForMember(dest => dest.schoolContactFamilyname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.familyName)))
             .ForMember(dest => dest.schoolContactFullname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.fullName)))
             .ForMember(dest => dest.schoolContactGivenname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.givenName)))
             .ForMember(dest => dest.schoolContactMiddlename, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.middleName)))
              .ForMember(dest => dest.schoolContactPreferredfamilyname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.preferredFamilyName)))
             .ForMember(dest => dest.schoolContactPreferredgivenname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.preferredGivenName)))
             .ForMember(dest => dest.schoolContactPrefix, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.prefix)))
             .ForMember(dest => dest.schoolContactSuffix, map => map.MapFrom(s => s.schoolContactList.Select(x => x.name.nameOfRecord.suffix)))
             .ForMember(dest => dest.schoolContactOtherNameFamilyname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.familyName))))
            .ForMember(dest => dest.schoolContactOtherNameFullname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.fullName))))
            .ForMember(dest => dest.schoolContactOtherNameGivenname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.givenName))))
            .ForMember(dest => dest.schoolContactOtherNameMiddlename, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.middleName))))
            .ForMember(dest => dest.schoolContactOtherNamePreferredfamilyname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.preferredFamilyName))))
            .ForMember(dest => dest.schoolContactOtherNamePreferredgivenname, map => map.MapFrom(s => s.schoolContactList.Select(x => x.otherNameList.Select(z => z.otherName.preferredGivenName))))
            .ForMember(dest=>dest.schoolContactphoneNumber,map=>map.MapFrom(s=>s.schoolContactList.Select(x=>x.phoneNumberList.Select(z=>z.number))))
            .ForMember(dest=>dest.schoolContactphoneNumberExtension,map=>map.MapFrom(s=>s.schoolContactList.Select(x=>x.phoneNumberList.Select(z=>z.extension))))
            .ForMember(dest=>dest.schoolContactphoneNumberTypeCode,map=>map.MapFrom(s=>s.schoolContactList.Select(x=>x.phoneNumberList.Select(z=>z.phoneNumberType.code))))
            .ForMember(dest => dest.schoolFocus, map => map.MapFrom(s => s.schoolFocusList.Select(x => x.ToArray())))
            .ForMember(dest => dest.schoolName, map => map.MapFrom(s => s.schoolName))
            .ForMember(dest => dest.schoolSector, map => map.MapFrom(s => s.schoolSector))
            .ForMember(dest=>dest.schoolTypeCode,map=>map.MapFrom(s=>s.schoolType.code))
            .ForMember(dest=>dest.schoolURL,map=>map.MapFrom(s=>s.schoolURL))
           .ForMember(dest=>dest.StatusId,map=>map.MapFrom(s=>statusId))
            .ForMember(dest=>dest.BatchId,map=>map.MapFrom(s=> ran.Next()))
           .ForMember(dest=>dest.CreatedBy,map=>map.MapFrom(s=> createdBy))
           .ForMember(dest=>dest.CreateDateTime,map=>map.MapFrom(s=>DateTime.Now))

            );
        }
    }
}
