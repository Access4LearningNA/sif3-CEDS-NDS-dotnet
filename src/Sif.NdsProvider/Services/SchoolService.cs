using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.Framework.Service.Serialisation;
using Sif.NdsProvider.Model;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;

namespace Sif.NdsProvider.Services
{
    public class SchoolService : IBasicProviderService<School>
    {
        private static IDictionary<string, School> schoolsCache = new Dictionary<string, School>();
        private static Random random = new Random();
       
        public School Create(School schoolObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {

            string refId = Guid.NewGuid().ToString();
            schoolObj.refId = refId;
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();
            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;User Id=SIFNDSAdmin;password=admin#123;MultipleActiveResultSets=true;App=EntityFramework");
            var org = new Organization();
            org.refId = Guid.NewGuid().ToString();
            var person = new Person();
            using (var _context = new CEDSContext(optionsBuilder.Options))
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
                if (schoolObj.localId != null)
                {
                    var orgIdentifier = Mapper.Map<OrganizationIdentifier>(schoolObj);
                    orgIdentifier.OrganizationId = org.OrganizationId;
                    _context.OrganizationIdentifier.Add(orgIdentifier);
                }
              
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
                    //var perOtherName=Mapper.Map<PersonOtherName>
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
