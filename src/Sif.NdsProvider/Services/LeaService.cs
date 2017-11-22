using AutoMapper;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.Framework.Service.Serialisation;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Person = SIF.NDSDataModel.Person;

namespace Sif.NdsProvider.Services
{
    public class LeaService : IBasicProviderService<Lea>
    {
        public Lea Create(Lea leaObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var org = new Organization();
            org.refId = leaObj.refId;
            var person = new Person();
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Organization.Add(org);
                var orgDetail = Mapper.Map<OrganizationDetail>(leaObj);
                orgDetail.OrganizationId = org.OrganizationId;
                orgDetail.RecordStartDateTime = DateTime.Now;
                _context.OrganizationDetail.Add(orgDetail);
                if (leaObj.phoneNumberList != null)
                {
                    var orgPhone = Mapper.Map<OrganizationTelephone>(leaObj);
                    orgPhone.OrganizationId = org.OrganizationId;
                    _context.OrganizationTelephone.Add(orgPhone);
                }
                if (leaObj.leaURL != null)
                {
                    var orgUrl = Mapper.Map<OrganizationWebsite>(leaObj);
                    orgUrl.OrganizationId = org.OrganizationId;
                    _context.OrganizationWebsite.Add(orgUrl);
                }
                if(leaObj.educationAgencyType !=null)
                {
                    var lea = Mapper.Map<K12Lea>(leaObj);
                    lea.OrganizationId = org.OrganizationId;
                    _context.K12Lea.Add(lea);
                }
                if(leaObj.operationalStatus !=null)
                {
                    var operStatus = Mapper.Map<OrganizationOperationalStatus>(leaObj);
                    operStatus.OrganizationId = org.OrganizationId;
                    _context.OrganizationOperationalStatus.Add(operStatus);
                }
                List<OrganizationIdentifier> orgIdentifier = new List<OrganizationIdentifier>();
                if (leaObj.externalIdList != null)
                {
                    var orgExternalIdIdentifier = new OrganizationIdentifier();
                    orgExternalIdIdentifier.Identifier = leaObj.externalIdList.Select(x=>x.idValue.ToString()).FirstOrDefault();
                    orgExternalIdIdentifier.RefOrganizationIdentificationSystemId = leaObj.externalIdList.Select(x=>x.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentificationSystemId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.RefOrganizationIdentifierTypeId = leaObj.externalIdList.Select(x=>x.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentifierTypeId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgExternalIdIdentifier);
                }
                if (leaObj.localId != null)
                {
                    var orgLocalIdIdentifier = new OrganizationIdentifier();
                    orgLocalIdIdentifier.Identifier = (leaObj.localId.idValue.ToString());
                    orgLocalIdIdentifier.RefOrganizationIdentificationSystemId = (leaObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentificationSystemId) : 0);
                    orgLocalIdIdentifier.RefOrganizationIdentifierTypeId = (leaObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentifierTypeId) : 0);
                    orgLocalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgLocalIdIdentifier);
                }
                _context.OrganizationIdentifier.AddRange(orgIdentifier);
                if (leaObj.leaContactList != null)
                {
                    _context.Person.Add(person);
                    var orgpersonrole = new OrganizationPersonRole();
                    orgpersonrole.PersonId = person.PersonId;
                    orgpersonrole.OrganizationId = org.OrganizationId;
                    orgpersonrole.RoleId = _context.Role.Where(x => x.Name == MyEnumClass.OrganizationContactRole).Select(y => y.RoleId).FirstOrDefault();
                    _context.OrganizationPersonRole.Add(orgpersonrole);

                    var perDetails = Mapper.Map<PersonDetail>(leaObj);
                    perDetails.PersonId = person.PersonId;
                    perDetails.RecordStartDateTime = DateTime.Now;
                    _context.PersonDetail.Add(perDetails);
                    var perTelephone = Mapper.Map<PersonTelephone>(leaObj);
                    perTelephone.PersonId = person.PersonId;
                    _context.PersonTelephone.Add(perTelephone);
                    var perEmail = Mapper.Map<PersonEmailAddress>(leaObj);
                    perEmail.PersonId = person.PersonId;
                    _context.PersonEmailAddress.Add(perEmail);
                    var perOtherName = Mapper.Map<PersonOtherName>(leaObj);
                    perOtherName.PersonId = person.PersonId;
                    _context.PersonOtherName.Add(perOtherName);
                    List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                    if (leaObj.leaContactList.FirstOrDefault().externalId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = leaObj.leaContactList.Select(x => x.externalId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(SchoolContactPersonExternalId.ExternalIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    if (leaObj.leaContactList.FirstOrDefault().localId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = leaObj.leaContactList.Select(x => x.localId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(SchoolContactPersonLocalId.localIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    if(perIdentifier.Count>0)
                    _context.PersonIdentifier.AddRange(perIdentifier);

                }
                var seaOrgId = _context.K12Sea.Select(x => x).OrderByDescending(y => y.OrganizationId).Take(1).FirstOrDefault();
                if (seaOrgId != null)
                {
                    var orgRelationship = new OrganizationRelationship();
                    orgRelationship.OrganizationId = org.OrganizationId;
                    orgRelationship.Parent_OrganizationId = seaOrgId.OrganizationId;
                    _context.OrganizationRelationship.Add(orgRelationship);
                }
                if (leaObj.addressRefIdList !=null)
                {
                    //need to implement
                }
                _context.SaveChanges();
            }
            return leaObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Lea Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Lea> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Lea> Retrieve(Lea obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Lea> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Lea obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
