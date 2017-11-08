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
        private static IDictionary<string, School> schoolsCache = new Dictionary<string, School>();
        private static Random random = new Random();
       
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
                    orgExternalIdIdentifier.Identifier = schoolObj.externalIdList.Select(x => x.idType.code.ToString() == "NCES Identification system" ? x.idValue.ToString() : null).FirstOrDefault();
                    orgExternalIdIdentifier.RefOrganizationIdentificationSystemId= schoolObj.externalIdList.Select(x => x.idValue != null ?Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentificationSystemId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.RefOrganizationIdentifierTypeId= schoolObj.externalIdList.Select(x => x.idValue != null ? Convert.ToInt32(SchoolExternalId.externalIdOrganizationIdentifierTypeId) : 0).FirstOrDefault();
                    orgExternalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgExternalIdIdentifier);
                }
                if (schoolObj.localId != null)
                {
                    var orgLocalIdIdentifier = new OrganizationIdentifier();
                    orgLocalIdIdentifier.Identifier = (schoolObj.localId.idType.code.ToString() == "State assigned number" ? schoolObj.localId.idValue.ToString() : null);
                    orgLocalIdIdentifier.RefOrganizationIdentificationSystemId = (schoolObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentificationSystemId) : 0);
                    orgLocalIdIdentifier.RefOrganizationIdentifierTypeId = (schoolObj.localId.idValue.ToString() != null ? Convert.ToInt32(SchoolLocalId.localIdOrganizationIdentifierTypeId) : 0);
                    orgLocalIdIdentifier.OrganizationId = org.OrganizationId;
                    orgIdentifier.Add(orgLocalIdIdentifier);
                }
                _context.OrganizationIdentifier.AddRange(orgIdentifier);

                if (schoolObj.schoolContactList != null)
                {
                    _context.Person.Add(person);
                   
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
