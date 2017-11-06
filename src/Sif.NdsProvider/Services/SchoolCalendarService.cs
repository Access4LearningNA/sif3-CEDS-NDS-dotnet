#region Namespace
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
#endregion

namespace Sif.NdsProvider.Services
{
    public class SchoolCalendarService : IBasicProviderService<SchoolCalendar>
    {
        public SchoolCalendar Create(SchoolCalendar schoolCalendarObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            string refId = Guid.NewGuid().ToString();
            schoolCalendarObj.refId = refId;
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();
            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;User Id=SIFNDSAdmin;password=admin#123;MultipleActiveResultSets=true;App=EntityFramework");
            using (var _context = new CEDSContext(optionsBuilder.Options))
            {
                if(schoolCalendarObj !=null)
                {
                    var orgCal = new OrganizationCalendar();
                    orgCal.OrganizationId =Convert.ToInt32(_context.Organization.Where(x => x.refId ==schoolCalendarObj.schoolRefId).Select(y => y.OrganizationId).FirstOrDefault());
                    orgCal.CalendarDescription = schoolCalendarObj.description;
                    orgCal.CalendarYear = schoolCalendarObj.schoolYear;
                    orgCal.CalendarCode = schoolCalendarObj.localId.idType.codesetName.ToString() == MyEnumClass.CalendarCode ? schoolCalendarObj.localId.idValue.ToString() : null;
                    _context.OrganizationCalendar.Add(orgCal);
                    var orgCalSession = Mapper.Map<OrganizationCalendarSession>(schoolCalendarObj);
                    orgCalSession.OrganizationCalendarId = orgCal.OrganizationCalendarId;
                    _context.OrganizationCalendarSession.Add(orgCalSession);
                }
                _context.SaveChanges();
            }
                return schoolCalendarObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }

        public SchoolCalendar Retrieve(string refId, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }

        public List<SchoolCalendar> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }

        public List<SchoolCalendar> Retrieve(SchoolCalendar obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }

        public List<SchoolCalendar> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }

        public void Update(SchoolCalendar obj, string zone = null, string context = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
