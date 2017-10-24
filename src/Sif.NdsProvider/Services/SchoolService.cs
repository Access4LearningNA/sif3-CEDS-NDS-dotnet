using AutoMapper;
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
            //var school = Mapper.Map<List<SchoolAttributes>>(schoolObj);
            //using (var _context = new CEDSContext())
            //{
            //    foreach (var schattr in school)
            //        _context.SchoolAttributes.Add(schattr);
            //    _context.SaveChanges();
            //}
            var ndsSchool = Mapper.Map<Organization>(schoolObj);
            using (var _context = new CEDSContext())
            {

                _context.Organization.Add(ndsSchool);
                if (ndsSchool.OrganizationWebsite != null)
                    _context.OrganizationWebsite.Add(ndsSchool.OrganizationWebsite);
                if (ndsSchool.OrganizationTelephone != null)
                    foreach (var orgtel in ndsSchool.OrganizationTelephone)
                        _context.OrganizationTelephone.Add(orgtel);
                if (ndsSchool.OrganizationEmail != null)
                    foreach (var orgEmail in ndsSchool.OrganizationEmail)
                        _context.OrganizationEmail.Add(orgEmail);
                if (ndsSchool.OrganizationDetail != null)
                    foreach (var orgDetail in ndsSchool.OrganizationDetail)
                        _context.OrganizationDetail.Add(orgDetail);
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
