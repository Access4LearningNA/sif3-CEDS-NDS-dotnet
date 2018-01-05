using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Linq;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class ContactPersonAssociationMapper : Profile
    {
        public override string ProfileName
        {
            get { return "ContactPersonAssociationMapper"; }
        }
        public ContactPersonAssociationMapper()
        {
            CreateMap<ContactPersonAssociation, PersonRelationship>()
               .ForMember(dest => dest.ContactPriorityNumber, map => map.MapFrom(src => src.contactSequence.ToString()))
               .ForMember(dest => dest.RefPersonRelationshipId, map => map.MapFrom(src => src.relationship.code != null ? CommonMethods.GetCodesetCode("RefPersonRelationship", "RefPersonRelationshipId", "Code", src.relationship.code):null));
               
               
        }
     }
}
