using AutoMapper;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;
using System.Linq;

namespace Sif.NdsProvider.Mappers
{
    public class AddressMapper:Profile
    {
        public override string ProfileName
        {
            get { return "AddressMapper"; }
        }
        public AddressMapper()
        {
           CreateMap<Address, OrganizationLocation>()
            .ForMember(dest => dest.RefOrganizationLocationTypeId, map => map.MapFrom(src => src.addressType.code.ToString() !=null? CommonMethods.GetCodesetCode("RefOrganizationLocationType", "RefOrganizationLocationTypeId", "Code", src.addressType.ToString()) : null))
             .ForMember(dest => dest.RefOrganizationLocationTypeId, map => map.MapFrom(src => src.addressType.otherCodeList.Select(x=>x.Value.ToString() != null ? CommonMethods.GetCodesetCode("RefOrganizationLocationType", "RefOrganizationLocationTypeId", "Code", src.addressType.ToString()) : null)));
           CreateMap<Address, LocationAddress>()
             .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.gridLocation.latitude))
            .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.gridLocation.longitude))
            .ForMember(dest => dest.PostalCode, map => map.MapFrom(src => src.postalCode.FirstOrDefault()))
            .ForMember(dest => dest.RefStateId, map => map.MapFrom(src => src.stateProvince.code.FirstOrDefault()))
            .ForMember(dest => dest.ApartmentRoomOrSuiteNumber, map => map.MapFrom(src => src.street.apartmentNumberPrefix.FirstOrDefault() + "," + src.street.apartmentNumber.FirstOrDefault() + "," + src.street.apartmentNumberSuffix.FirstOrDefault()))
            .ForMember(dest => dest.StreetNumberAndName, map => map.MapFrom(src => src.street.line1.FirstOrDefault() + "," + src.street.line2.FirstOrDefault() + "," + src.street.line3.FirstOrDefault() + "," + src.street.streetName.FirstOrDefault() + "," + src.street.streetNumber.FirstOrDefault() + "," + src.street.streetPrefix.FirstOrDefault() + "," + src.street.streetSuffix.FirstOrDefault() + "," + src.street.streetType.FirstOrDefault()));
        }
    }
}
