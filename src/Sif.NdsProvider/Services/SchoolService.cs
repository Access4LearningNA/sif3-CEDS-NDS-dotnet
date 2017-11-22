using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.Framework.Service.Serialisation;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Person= SIF.NDSDataModel.Person;

namespace Sif.NdsProvider.Services
{
    public class SchoolService : IBasicProviderService<School>
    {
       
        public School Create(School schoolObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var org = new Organization();
            org.refId = schoolObj.refId;
            var person = new Person();
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Organization.Add(org);
                var orgDetail = Mapper.Map<OrganizationDetail>(schoolObj);
                orgDetail.OrganizationId = org.OrganizationId;
                orgDetail.RecordStartDateTime = DateTime.Now;
                _context.OrganizationDetail.Add(orgDetail);
                if (schoolObj.phoneNumberList != null)
                {
                    var orgPhone = Mapper.Map<OrganizationTelephone>(schoolObj);
                    orgPhone.OrganizationId = org.OrganizationId;
                    _context.OrganizationTelephone.Add(orgPhone);
                }
                if (schoolObj.emailList != null)
                {
                    var orgEmail = Mapper.Map<OrganizationEmail>(schoolObj);
                    orgEmail.OrganizationId = org.OrganizationId;
                    _context.OrganizationEmail.Add(orgEmail);
                }
                if (schoolObj.operationalStatus != null)
                {
                    var orgOperationalStatus = Mapper.Map<OrganizationOperationalStatus>(schoolObj);
                    orgOperationalStatus.OrganizationId = org.OrganizationId;
                    _context.OrganizationOperationalStatus.Add(orgOperationalStatus);
                }
                List<OrganizationIdentifier> orgIdentifier = new List<OrganizationIdentifier>();
                if (schoolObj.externalIdList != null)
                {
                    var orgExternalIdIdentifier = new OrganizationIdentifier();
                    orgExternalIdIdentifier.Identifier = schoolObj.externalIdList.Select(x =>x.idValue.ToString()).FirstOrDefault() ;
                    orgExternalIdIdentifier.RefOrganizationIdentificationSystemId= schoolObj.externalIdList.Select(x => x.idValue != null ?Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentificationSystemId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.RefOrganizationIdentifierTypeId= schoolObj.externalIdList.Select(x => x.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentifierTypeId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgExternalIdIdentifier);
                }
                if (schoolObj.localId != null)
                {
                    var orgLocalIdIdentifier = new OrganizationIdentifier();
                    orgLocalIdIdentifier.Identifier = (schoolObj.localId.idValue.ToString());
                    orgLocalIdIdentifier.RefOrganizationIdentificationSystemId = (schoolObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentificationSystemId) : 0);
                    orgLocalIdIdentifier.RefOrganizationIdentifierTypeId = (schoolObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentifierTypeId) : 0);
                    orgLocalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgLocalIdIdentifier);
                }
                _context.OrganizationIdentifier.AddRange(orgIdentifier);

                if (schoolObj.schoolContactList != null)
                {
                    _context.Person.Add(person);
                    var orgpersonrole = new OrganizationPersonRole();
                    orgpersonrole.PersonId = person.PersonId;
                    orgpersonrole.OrganizationId = org.OrganizationId;
                    orgpersonrole.RoleId = _context.Role.Where(x => x.Name == MyEnumClass.OrganizationContactRole).Select(y => y.RoleId).FirstOrDefault();
                    _context.OrganizationPersonRole.Add(orgpersonrole);

                    var perDetails = Mapper.Map<PersonDetail>(schoolObj);
                    perDetails.PersonId = person.PersonId;
                    perDetails.RecordStartDateTime = DateTime.Now;
                    _context.PersonDetail.Add(perDetails);
                    var perAddr = Mapper.Map<PersonAddress>(schoolObj);
                    perAddr.PersonId = person.PersonId;
                    _context.PersonAddress.Add(perAddr);
                    var perTelephone = Mapper.Map<PersonTelephone>(schoolObj);
                    perTelephone.PersonId = person.PersonId;
                    _context.PersonTelephone.Add(perTelephone);
                    var perEmail = Mapper.Map<PersonEmailAddress>(schoolObj);
                    perEmail.PersonId = person.PersonId;
                    _context.PersonEmailAddress.Add(perEmail);
                    var perOtherName = Mapper.Map<PersonOtherName>(schoolObj);
                    perOtherName.PersonId = person.PersonId;
                    _context.PersonOtherName.Add(perOtherName);
                    List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                    if (schoolObj.schoolContactList.FirstOrDefault().externalId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = schoolObj.schoolContactList.Select(x => x.externalId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(SchoolContactPersonExternalId.ExternalIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    if (schoolObj.schoolContactList.FirstOrDefault().localId != null)
                    {
                        var personIdentifier = new PersonIdentifier();
                        personIdentifier.PersonId = person.PersonId;
                        personIdentifier.Identifier = schoolObj.schoolContactList.Select(x => x.localId.idValue.ToString()).FirstOrDefault();
                        personIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(SchoolContactPersonLocalId.localIdPersonIdentificationSystemId);
                        perIdentifier.Add(personIdentifier);
                    }
                    _context.PersonIdentifier.AddRange(perIdentifier);
                }
                if (schoolObj.schoolFocusList != null && schoolObj.schoolSector != null)
                {
                    var orgK12School = Mapper.Map<K12School>(schoolObj);
                    orgK12School.OrganizationId = org.OrganizationId;
                    orgK12School.RecordStartDateTime = DateTime.Now;
                    _context.K12School.Add(orgK12School);
                }
                if (schoolObj.schoolURL != null)
                {
                     var orgWebSite = Mapper.Map<OrganizationWebsite>(schoolObj);
                    orgWebSite.OrganizationId = org.OrganizationId;
                    _context.OrganizationWebsite.Add(orgWebSite);
                }
                if(schoolObj.leaRefId !=null)
                {
                    var orgId = _context.Organization.Where(x => x.refId == schoolObj.leaRefId).Select(y => y.OrganizationId).FirstOrDefault();
                    var orgRelationship = new OrganizationRelationship();
                    orgRelationship.OrganizationId = org.OrganizationId;
                    orgRelationship.Parent_OrganizationId = _context.K12Lea.Where(x => x.OrganizationId == orgId).Select(y => y.OrganizationId).FirstOrDefault();
                    _context.OrganizationRelationship.Add(orgRelationship);
                }
                _context.SaveChanges();
            }

            return schoolObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public School Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<School> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<School> Retrieve(School obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<School> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(School obj, string zone = null, string context = null)
        {
            //throw new NotImplementedException();
            //if (studentsCache.ContainsKey(obj.RefId))
            //{
            //    studentsCache.Remove(obj.RefId);
            //    studentsCache.Add(obj.RefId, obj);
            //}

        }
    }
}
