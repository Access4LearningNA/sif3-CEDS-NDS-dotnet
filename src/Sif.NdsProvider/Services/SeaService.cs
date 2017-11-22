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
    public class SeaService : IBasicProviderService<Sea>
    {
        public Sea Create(Sea seaObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var org = new Organization();
            var sea = new K12Sea();
            org.refId = seaObj.refId;
            var person = new Person();
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Organization.Add(org);
                sea.OrganizationId = org.OrganizationId;
                _context.K12Sea.Add(sea);
                var orgDetail = Mapper.Map<OrganizationDetail>(seaObj);
                orgDetail.OrganizationId = org.OrganizationId;
                orgDetail.RecordStartDateTime = DateTime.Now;
                _context.OrganizationDetail.Add(orgDetail);
                if (seaObj.phoneNumberList != null)
                {
                    var orgPhone = Mapper.Map<OrganizationTelephone>(seaObj);
                    orgPhone.OrganizationId = org.OrganizationId;
                    _context.OrganizationTelephone.Add(orgPhone);
                }
                if (seaObj.seaURL != null)
                {
                    var orgUrl = Mapper.Map<OrganizationWebsite>(seaObj);
                    orgUrl.OrganizationId = org.OrganizationId;
                    _context.OrganizationWebsite.Add(orgUrl);
                }
                List<OrganizationIdentifier> orgIdentifier = new List<OrganizationIdentifier>();
                if (seaObj.ncesId != null)
                {
                    var orgExternalIdIdentifier = new OrganizationIdentifier();
                    orgExternalIdIdentifier.Identifier = seaObj.ncesId.idValue.ToString();
                    orgExternalIdIdentifier.RefOrganizationIdentificationSystemId = seaObj.ncesId.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentificationSystemId) : 0;
                    orgExternalIdIdentifier.RefOrganizationIdentifierTypeId = seaObj.ncesId.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentifierTypeId) : 0;
                    orgExternalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgExternalIdIdentifier);
                }
                if (seaObj.localId != null)
                {
                    var orgLocalIdIdentifier = new OrganizationIdentifier();
                    orgLocalIdIdentifier.Identifier = (seaObj.localId.idValue.ToString());
                    orgLocalIdIdentifier.RefOrganizationIdentificationSystemId = (seaObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentificationSystemId) : 0);
                    orgLocalIdIdentifier.RefOrganizationIdentifierTypeId = (seaObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentifierTypeId) : 0);
                    orgLocalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgLocalIdIdentifier);
                }
                _context.OrganizationIdentifier.AddRange(orgIdentifier);
                if (seaObj.seaContactList != null)
                {
                    _context.Person.Add(person);
                    var orgpersonrole = new OrganizationPersonRole();
                    orgpersonrole.PersonId = person.PersonId;
                    orgpersonrole.OrganizationId = org.OrganizationId;
                    orgpersonrole.RoleId = _context.Role.Where(x => x.Name == MyEnumClass.OrganizationContactRole).Select(y => y.RoleId).FirstOrDefault();
                    _context.OrganizationPersonRole.Add(orgpersonrole);

                    var perDetails = Mapper.Map<PersonDetail>(seaObj);
                    perDetails.PersonId = person.PersonId;
                    perDetails.RecordStartDateTime = DateTime.Now;
                    _context.PersonDetail.Add(perDetails);
                    var perAddr = Mapper.Map<PersonAddress>(seaObj);
                    perAddr.PersonId = person.PersonId;
                    _context.PersonAddress.Add(perAddr);
                    var perTelephone = Mapper.Map<PersonTelephone>(seaObj);
                    perTelephone.PersonId = person.PersonId;
                    _context.PersonTelephone.Add(perTelephone);
                    var perEmail = Mapper.Map<PersonEmailAddress>(seaObj);
                    perEmail.PersonId = person.PersonId;
                    _context.PersonEmailAddress.Add(perEmail);
                    var perOtherName = Mapper.Map<PersonOtherName>(seaObj);
                    perOtherName.PersonId = person.PersonId;
                    _context.PersonOtherName.Add(perOtherName);
                    List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                    if (seaObj.seaContactList.FirstOrDefault().externalId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = seaObj.seaContactList.Select(x => x.externalId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId= Convert.ToInt32(SchoolContactPersonExternalId.ExternalIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    if (seaObj.seaContactList.FirstOrDefault().localId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = seaObj.seaContactList.Select(x => x.localId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(SchoolContactPersonLocalId.localIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    if(perIdentifier.ToList().Count>0)
                    _context.PersonIdentifier.AddRange(perIdentifier);
                    

                }
                _context.SaveChanges();
            }
            return seaObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Sea Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Sea> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Sea> Retrieve(Sea obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Sea> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Sea obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
